namespace Metro2036.DataImporter
{
    using Metro2036.Data;
    using Metro2036.DataImporter.Dto.ImportDto;
    using Metro2036.Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static void SeedStations(Metro2036DbContext context, StationDtoImp[] seedStations)
        {
            var station = Mapper.Map<Station>(StationDtoImp);

            var validStations = new List<Station>();

            validStations.Add(station);

            context.Stations.AddRange(validStations);
            context.SaveChanges();

        }

        public static string ImportJsonStations(Metro2036DbContext context, string jsonString)
        {
            //Import Stations from JSON with DTO and AutoMapper
            StringBuilder sb = new StringBuilder();

            var deserializedStations = JsonConvert.DeserializeObject<StationDtoImp[]>(jsonString);

            var validStations = new List<Station>();

            foreach (var stationDto in deserializedStations)
            {
                if (!IsValid(stationDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var stationAlreadyExists = validStations.Any(s => s.Name == stationDto.Name);

                if (stationAlreadyExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var station = Mapper.Map<Station>(stationDto);

                validStations.Add(station);

                sb.AppendLine(string.Format(SuccessMessage, stationDto.Name));
                //Console.WriteLine($"{stationDto.Name} {stationDto.Longitude} {stationDto.Latitude}");

            }

            context.Stations.AddRange(validStations);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }


        public static string ImportJsonRoutes(Metro2036DbContext context, string jsonString)
        {
            //Import Stations from JSON with DTO
            StringBuilder sb = new StringBuilder();

            //var deserializedRoutes = JsonConvert.DeserializeObject<RouteDtoImp[]>(jsonString);
            var deserializedRoutes = JsonConvert.DeserializeObject<List<RouteDtoImp>>(jsonString);

            var validRoutes = new List<Route>();

            foreach (var routeDto in deserializedRoutes)
            {
                if (!IsValid(routeDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var routeAlreadyExists = validRoutes.Any(s => s.RouteName == routeDto.RouteName);

                if (routeAlreadyExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                //var route = Mapper.Map<Route>(routeDto);

                var impPoints = routeDto.Points;

                var validPoints = new List<Point>();

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

                sb.AppendLine(string.Format(SuccessMessage, routeDto.RouteName));
                //Console.WriteLine($"{stationDto.Name} {stationDto.Longitude} {stationDto.Latitude}");

            }

            context.Routes.AddRange(validRoutes);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }
        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            return isValid;
        }


    }
}
