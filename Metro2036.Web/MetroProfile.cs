namespace Metro2036.Web
{
    using AutoMapper;
    using Metro2036.Web.Models.DTO.ImportDTO;
    using Metro2036.Models;
    using Metro2036.Services.Models.Station;
    using Metro2036.Web.Areas.Admin.Models.User;

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

            //Users
            CreateMap<UserListingServiceModel, User>();

            //TravelLog
            CreateMap<TravelLogDtoImp, TravelLog>();

            //ViewStation
            CreateMap<StationDetailsViewModel, Station>();
            //BindStation
            CreateMap<StationEditBindModel, Station>();
            //DeleteStation
            CreateMap<StationDeleteViewModel, Station>();



        }
    }
}
