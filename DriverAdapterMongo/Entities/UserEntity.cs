using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverAdapterMongo.Entities
{
    public class UserEntity
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string id_user { get; set; }
        public string id_fire { get; set; }
        public string user { get; set; }
        public string password { get; set; }

        public bool estate = true;


    }
}
