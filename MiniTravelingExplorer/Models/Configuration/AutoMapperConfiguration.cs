using AutoMapper;

namespace MiniTravelingExplorer.Models.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static Mapper InitializeAutomapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<EntityModel.User, User>();
                config.CreateMap<EntityModel.SecurityQuestions, SecurityQuestions>();
                config.CreateMap<EntityModel.HomePageData, HomePageData>();
                config.CreateMap<EntityModel.Room, Room>();
                config.CreateMap<EntityModel.Staff, Staff>();
                config.CreateMap<EntityModel.Testimonial, Testimonial>();
                config.CreateMap<EntityModel.Location, Location>();
                config.CreateMap<EntityModel.Activity, Activity>();
                config.CreateMap<EntityModel.Weather, WeatherDescription>();
                config.CreateMap<EntityModel.Booking, Booking>();
                config.CreateMap<EntityModel.Checklist, Checklist>();
                config.CreateMap<EntityModel.MyChecklist, MyChecklist>();
                config.CreateMap<EntityModel.MyChecklistItem, MyChecklistItem>();
                config.CreateMap<EntityModel.ActiveBooking, ActiveBooking>();
                config.CreateMap<EntityModel.UserIpInfo, UserIpInfo>();
            });

            Mapper mapper = new Mapper(mapperConfiguration);
            return mapper;
        }
    }
}