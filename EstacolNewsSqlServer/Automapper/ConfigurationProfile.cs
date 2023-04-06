using EstacolNews.Domain.Sql.Commands;
using AutoMapper;
using EstacolNews.Domain.Sql.Entities;
using System.IO;

namespace EstacolNewsSqlServer.Automapper
{
    public class ConfigurationProfile : Profile
    {

        public ConfigurationProfile()
        {
            CreateMap<InsertNewEditor, Editor>().ReverseMap();

            CreateMap<InsertNewContent, Content>().ReverseMap();


        }

    }
}
