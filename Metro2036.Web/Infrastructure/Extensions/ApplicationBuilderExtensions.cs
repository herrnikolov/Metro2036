namespace Metro2036.Web.Infrastructure.Extensions
{
    using AutoMapper;
    using Metro2036.Data;
    using Metro2036.Models;
    using Metro2036.Web.Models.DTO.ImportDTO;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<Metro2036DbContext>();
                var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                context.Database.Migrate();

                //TODO: Rework Seeds

                //Seed Users and Roles
                SeedDefaultRoles(userManager, roleManager);
                SeedUsers(context, userManager);

                //SeedStations
                if (!context.Stations.Any())
                {
                    var deserializedStations = File.ReadAllText(WebConstants.StationsListPath);
                    var stationDtos = JsonConvert.DeserializeObject<StationDtoImp[]>(deserializedStations);

                    SeedStations(context, stationDtos);
                }
                //SeedRoutes and Points
                if (!context.Routes.Any())
                {
                    var deserializedRoutes = File.ReadAllText(WebConstants.RoutesListPath);
                    var routeDtos = JsonConvert.DeserializeObject<RouteDtoImp[]>(deserializedRoutes);

                    SeedRoutes(context, routeDtos);
                }
                //SeedTrains
                if (!context.Trains.Any())
                {
                    var deserializedTrains = File.ReadAllText(WebConstants.TrainsListPath);
                    var trainDtos = JsonConvert.DeserializeObject<TrainDtoImp[]>(deserializedTrains);

                    SeedTrains(context, trainDtos);
                }
                //SeedTravelLog
                if (!context.TravelLogs.Any())
                {
                    var deserializedTravelLog = File.ReadAllText(WebConstants.TravelLogsListPath);
                    var travelLogsDtos = JsonConvert.DeserializeObject<TravelLogDtoImp[]>(deserializedTravelLog);

                    SeedTravelLog(context, travelLogsDtos);
                }
            }
            return app;
        }

        private static void SeedStations(Metro2036DbContext context, StationDtoImp[] deserializedStations)
        {
            var validStations = new List<Station>();

            foreach (var stationDto in deserializedStations)
            {

                var stationAlreadyExists = validStations.Any(s => s.Name == stationDto.Name);

                var station = Mapper.Map<Station>(stationDto);

                validStations.Add(station);

                //TODO: Implement Import Logging
            }

            context.Stations.AddRange(validStations);
            context.SaveChanges();
        }

        private static void SeedRoutes(Metro2036DbContext context, RouteDtoImp[] deserializedRoutes)
        {
            var validRoutes = new List<Route>();
            var validPoints = new List<Point>();

            foreach (var routeDto in deserializedRoutes)
            {

                var routeAlreadyExists = validRoutes.Any(s => s.RouteName == routeDto.RouteName);

                //var route = Mapper.Map<Route>(routeDto);
                //validRoutes.Add(route);

                var impPoints = routeDto.Points;

                foreach (var pointDtoImp in impPoints)
                {
                    var PointToAdd = new Point
                    {
                        stop = pointDtoImp.stop,
                        StopCode = pointDtoImp.StopCode,
                        StopName = pointDtoImp.StopName,
                        Latitude = pointDtoImp.Latitude,
                        Longitude = pointDtoImp.Longitude,
                        VehicleType = pointDtoImp.VehicleType,
                    };
                    validPoints.Add(PointToAdd);

                }

                var route = new Route
                {
                    Id = routeDto.Id,
                    RouteId = routeDto.RouteId,
                    Type = routeDto.Type,
                    RouteName = routeDto.RouteName,
                    LineId = routeDto.LineId,
                    ExtId = routeDto.ExtId,
                    LineName = routeDto.LineName,
                    Points = validPoints
                };

                validRoutes.Add(route);

                //TODO: Implement Import Logging
            }

            context.Routes.AddRange(validRoutes);
            context.Points.AddRange(validPoints);
            context.SaveChanges();
        }

        private static void SeedTrains(Metro2036DbContext context, TrainDtoImp[] deserializedTrains)
        {
            var validTrains = new List<Train>();

            foreach (var trainDto in deserializedTrains)
            {
                var trainAlreadyExists = deserializedTrains.Any(s => s.SerialNumber == trainDto.SerialNumber);

                var train = Mapper.Map<Train>(trainDto);

                validTrains.Add(train);

                //TODO: Implement Import Logging
            }

            context.Trains.AddRange(validTrains);
            context.SaveChanges();
        }

        private static void SeedDefaultRoles(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            Task
                .Run(async () =>
                {
                    var adminRoleName = WebConstants.AdministratorRole;
                    var userRoleName = WebConstants.UserRole;
                    var roles = new[]
                    {
                        adminRoleName,
                        userRoleName
                    };

                    foreach (var role in roles)
                    {
                        var roleExist = await roleManager.RoleExistsAsync(role);

                        if (!roleExist)
                        {
                            await roleManager.CreateAsync(new IdentityRole(role));
                        }
                    }

                    await RegisterAdminUser(userManager, adminRoleName);
                })
                .Wait();
        }
        private static async Task RegisterAdminUser(UserManager<User> userManager, string adminRoleName)
        {
            var adminEmail = WebConstants.AdminEmail;
            var adminUserName = WebConstants.AdminUserName;

            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new User
                {
                    Email = adminEmail,
                    UserName = adminUserName
                };

                await userManager.CreateAsync(adminUser, WebConstants.AdminPassword);

                await userManager.AddToRoleAsync(adminUser, adminRoleName);
            }
        }
        private static void SeedUsers(Metro2036DbContext context, UserManager<User> userManager)
        {
            if (context.Users.Count() <= 1)
            {
                var usersList = File
                .ReadAllText(WebConstants.UsersListPath);

                var deserializedUsers = JsonConvert.DeserializeObject<User[]>(usersList);

                Task.Run(async () =>
                {
                    foreach (var user in deserializedUsers)
                    {
                        var result = await userManager.CreateAsync(user, WebConstants.UserPassword);
                    }
                    foreach (var user in deserializedUsers)
                    {
                        var result = await userManager.AddToRoleAsync(user, WebConstants.UserRole);
                    }
                })
                .GetAwaiter()
                .GetResult();
            }
        }

        private static void SeedTravelLog(Metro2036DbContext context, TravelLogDtoImp[] travelLogsDtos)
        {
            var validTravelLog = new List<TravelLog>();

            foreach (var travelLogDto in travelLogsDtos)
            {
                var userId = context.Users
                    .Where(u => u.UserName == travelLogDto.UserName)
                    .Select(u => u.Id)
                    .Single();
                var stationId = travelLogDto.StationId;

                //var travelLog = Mapper.Map<TravelLog>(travelLogDto);

                var travelLog = new TravelLog
                {
                    UserId = userId,
                    StationId = stationId
                };


                validTravelLog.Add(travelLog);

                //TODO: Implement Import Logging
            }

            context.TravelLogs.AddRange(validTravelLog);
            context.SaveChanges();
        }
    }
}
