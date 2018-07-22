namespace Metro2036.Web.Infrastructure.Extensions
{
    using Metro2036.Data;
    using Metro2036.Web.Models.Dto.ImportDTO;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
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

                if (!context.Stations.Any())
                {
                    var jsonStations = File.ReadAllText(@"wwwroot\seedfiles\metro_stations.json");
                    var stationsDtos = JsonConvert.DeserializeObject<StationDtoImp[]>(jsonStations);

                    SeedStations(context, stationsDtos);
                }
            }

            return app;
        }
        private static void SeedStations(Metro2036DbContext context, StationDtoImp[] seedStations)
        {
            var station = Mapper.Map<Station>(stationDto);

            var validStations = new List<Station>();

            validStations.Add(station);

            context.Stations.AddRange(validStations);
            context.SaveChanges();

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
