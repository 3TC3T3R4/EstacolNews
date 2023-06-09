﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacolNews.Domain.Sql.Entities
{
    public class Content
    {
        public int id_content { get; set; }
        public string title { get; set; }
        public string estate_process = "Editando";
        public bool estate = true;
        public string keywords { get; set; }
        public string type_publication { get; set; }
        public string url { get; set; }
        public DateTime finish_date { get; set; }
        public DateTime publication_date { get; set; }
        public DateTime program_date { get; set; }
        public int number_of_collaborators { get; set; }
        public int likes { get; set; }
        public int dislikes { get; set; }
        public int number_of_share { get; set; }
        public string description { get; set; }


    }
}
