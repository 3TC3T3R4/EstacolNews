using DriverAdapterMongo.Entities;
using MongoDB.Driver;


namespace DriverAdapterMongo.Interfaces
{
    public interface IContext
    {



        public IMongoCollection<UserEntity> User { get; }


    }
}
