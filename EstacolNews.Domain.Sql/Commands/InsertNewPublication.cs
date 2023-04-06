using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacolNews.Domain.Sql.Commands
{
    public class InsertNewPublication
    {
       // public int id_publication { get; set; }
        public int id_editor_publication { get; set; }
        public int id_content_publication { get; set; }
        public string author { get; set; }
        public bool estate { get; set; }
    }
}
