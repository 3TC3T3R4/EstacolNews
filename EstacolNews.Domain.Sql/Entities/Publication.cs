﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacolNews.Domain.Sql.Entities
{
    public class Publication
    {

        public int id_publication { get; set; }
        public string id_editor_publication { get; set; }
        public int id_content_publication { get; set; }
        public bool estate = true;





    }
}
