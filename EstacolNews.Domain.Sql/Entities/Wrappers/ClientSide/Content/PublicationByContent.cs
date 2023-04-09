using EstacolNews.Domain.Sql.Entities.Wrappers.ClientSide.Publication;
using EstacolNews.Domain.Sql.Entities.Wrappers.EditorSide.Publication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacolNews.Domain.Sql.Entities.Wrappers.ClientSide.Content
{
    public class PublicationByContent
    {
        public string title { get; set; }
        public List<PublicationWithEditors> Publications { get; set; } = new();




    }
}
