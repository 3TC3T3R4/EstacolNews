using EstacolNews.Domain.Sql.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacolNews.Domain.Sql.Entities.Wrappers.EditorSide.Publication
{
    public class PublicationsWithContents
    {
        public int id_publication { get; set; }
        public List<Content> Content { get; set; } = new();



    }
}
