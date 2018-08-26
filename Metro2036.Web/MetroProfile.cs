namespace Metro2036.Web
{
    using AutoMapper;
    using Metro2036.Web.Models.DTO.ImportDTO;
    using Metro2036.Models;
    using Metro2036.Services.Models.Station;

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
            CreateMap<UserDtoImp, User>();

            //TravelLog
            CreateMap<TravelLogDtoImp, TravelLog>();

            //Station:
            //ViewStation
            CreateMap<StationDetailsViewModel, Station>();
            //BindStation
            CreateMap<StationEditBindModel, Station>();
            //DeleteStation
            CreateMap<StationDeleteViewModel, Station>();
            //CreateStation
            CreateMap<StationCreateViewModel, Station>();

        }
    }
}
