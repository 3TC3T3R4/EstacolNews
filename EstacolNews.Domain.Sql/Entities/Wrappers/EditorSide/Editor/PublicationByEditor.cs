using EstacolNews.Domain.Sql.Entities.Wrappers.EditorSide.Publication;


namespace EstacolNews.Domain.Sql.Entities.Wrappers.EditorSide.Editor
{
    public class PublicationByEditor
    {

        public string completeName { get; set; }
        public List<PublicationsWithContents> Publications { get; set; } = new();






    }
}
