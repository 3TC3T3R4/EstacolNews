using AutoMapper;
using DriverAdapterMongo.Entities;
using DriverAdapterMongo.Interfaces;
using EstacolNews.Domain.NoSql.Entities;
using EstacolNews.UseCases.NoSql.Gateway.Repositories.Commands;
using MongoDB.Driver;

namespace DriverAdapterMongo.Repositories
{
  public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserEntity> userCollection;
        private readonly IMapper _mapper;
        public UserRepository(IContext context, IMapper mapper)
        {
            this.userCollection = context.User;
            _mapper = mapper;
        }
        public async Task<User> InsertUserAsync(User user)
        {
            var userSave = _mapper.Map<UserEntity>(user);
            await userCollection.InsertOneAsync(userSave);
            return user;
        }

    }
}
