using DriverAdapterMongo.Entities;
using DriverAdapterMongo.Interfaces;
using MongoDB.Driver;

namespace DriverAdapterMongo
{
   public class Context : IContext
       
    {
        private readonly IMongoDatabase _database;

        public Context(string stringConnection, string DBname)
        {
            MongoClient cliente = new(stringConnection);
            _database = cliente.GetDatabase(DBname);
        }

        public IMongoCollection<UserEntity>User => _database.GetCollection<UserEntity>("Users");

       
    }
}
