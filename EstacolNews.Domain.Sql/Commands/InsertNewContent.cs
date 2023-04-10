using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacolNews.Domain.Sql.Commands
{
    public class InsertNewContent
    {

        public string title { get; set; }
        //public string estate_process { get; set; }
        public string keywords { get; set; }
        //public string type_publication { get; set; }
      // public string url { get; set; }
        public DateTime finish_date { get; set; }
        public DateTime publication_date { get; set; }
        public DateTime program_date { get; set; }
        public string description { get; set; }

    }
}
