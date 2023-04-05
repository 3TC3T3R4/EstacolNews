using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;

namespace EstacolNewsSqlServer.Automapper
{
    public class ConfigurationProfile
    {

        public ConfigurationProfile()
        {
            CreateMap<InsertNewEditor, Editor>().ReverseMap();
            



        }


    }
}
