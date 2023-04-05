using AutoMapper;
using DriverAdapterMongo.Entities;
using EstacolNews.Domain.NoSql.Commands;
using EstacolNews.Domain.NoSql.Entities;

namespace EstacolNewsWithMongo.Automapper
{
    public class ConfigurationProfile : Profile
    {

        public ConfigurationProfile() { 
        CreateMap<InsertNewUser, User>().ReverseMap();
        CreateMap<UserEntity, User>().ReverseMap();

    }
    }
}
