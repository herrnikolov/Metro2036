namespace Metro2036.Web
{
    using AutoMapper;
    using Metro2036.Web.Models.DTO.ImportDTO;
    using Metro2036.Models;

    public class MetroProfile : Profile
    {
        public MetroProfile()
        {
            // Stantions
            CreateMap<StationDtoImp, Station>();
            CreateMap<RouteDtoImp, Route>();

            // Route
            CreateMap<RouteDtoImp, Route>();

            //Train
            CreateMap<TrainDtoImp, Train>();

            //Passenger
            CreateMap<PasswngerDtoImp, Passenger>();
        }
    }
}
