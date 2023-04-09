

namespace EstacolNews.Domain.Sql.Entities.Wrappers.ClientSide.Publication
{
    public class PublicationWithEditors
    {
        public int id_publication { get; set; }
        public List<Editor> Editor { get; set; } = new();


    }
}
