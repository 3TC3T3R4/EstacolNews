using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacolNews.Domain.NoSql.Entities
{
    public class User
    {

        public string id_fire { get; set; }
        public string user { get; set; }
        public string password { get; set; }

        public int role = 1;

        public bool estate = false;



    }
}
