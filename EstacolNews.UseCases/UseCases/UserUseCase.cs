using EstacolNews.Domain.NoSql.Entities;
using EstacolNews.UseCases.NoSql.Gateway;
using EstacolNews.UseCases.NoSql.Gateway.Repositories.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacolNews.UseCases.NoSql.UseCases
{
    public class UserUseCase : IUserUseCase
    {

        private readonly IUserRepository _userRepository;

        public UserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddUser(User user)
        {
            return await _userRepository.InsertUserAsync(user);
        }
    }
}
