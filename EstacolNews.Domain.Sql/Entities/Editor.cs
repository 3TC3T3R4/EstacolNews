using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacolNews.Domain.Sql.Entities
{
   public class Editor
    {
        public int id_Editor { get; set; }
        public string id_user { get; set; }
        //public string  user { get; set; }
        //public string password { get; set; }
        //public int role { get; set; }
        public string complete_name { get; set; }
        public string phone { get; set; }
        public bool estate { get; set; }


    }
}
