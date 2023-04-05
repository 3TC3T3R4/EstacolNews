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
