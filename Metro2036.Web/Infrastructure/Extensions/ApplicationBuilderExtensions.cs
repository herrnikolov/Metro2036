namespace Metro2036.Web.Infrastructure.Extensions
{
    using AutoMapper;
    using Metro2036.Data;
    using Metro2036.Models;
    using Metro2036.Web.Models.DTO.ImportDTO;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<Metro2036DbContext>();

                context.Database.Migrate();
                //SeedStations
                if (!context.Stations.Any())
                {
                    var deserializedStations = File.ReadAllText(@"wwwroot\seedfiles\metro_stations.json");
                    var stationDtos = JsonConvert.DeserializeObject<StationDtoImp[]>(deserializedStations);

                    SeedStations(context, stationDtos);
                }
                //SeedRoutes and Points
                if (!context.Routes.Any())
                {
                    var deserializedRoutes = File.ReadAllText(@"wwwroot\seedfiles\routes.json");
                    var routeDtos = JsonConvert.DeserializeObject<RouteDtoImp[]>(deserializedRoutes);

                    SeedRoutes(context, routeDtos);
                }
                //SeedTrains
                if (!context.Trains.Any())
                {
                    var deserializedTrains = File.ReadAllText(@"wwwroot\seedfiles\trains.json");
                    var trainDtos = JsonConvert.DeserializeObject<TrainDtoImp[]>(deserializedTrains);

                    SeedTrains(context, trainDtos);
                }
                //SeedPassengers
                //if (!context.Passengers.Any())
                //{
                //    var deserializedPassengers = File.ReadAllText(@"wwwroot\seedfiles\passengers.json");
                //    var passengerDtos = JsonConvert.DeserializeObject<PasswngerDtoImp[]>(deserializedPassengers);

                //    SeedPassengers(context, passengerDtos);
                //}
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

        private static void SeedPassengers(Metro2036DbContext context, PasswngerDtoImp[] deserializedPassengers)
        {
            var validPassengers = new List<User>();

            foreach (var passengerDto in deserializedPassengers)
            {
                var passengerAlreadyExists = deserializedPassengers.Any(s => s.TravelId== passengerDto.TravelId);

                var passenger = Mapper.Map<User>(passengerDto);

                validPassengers.Add(passenger);

                //TODO: Implement Import Logging
            }

            context.Passengers.AddRange(validPassengers);
            context.SaveChanges();
        }
    }
}
