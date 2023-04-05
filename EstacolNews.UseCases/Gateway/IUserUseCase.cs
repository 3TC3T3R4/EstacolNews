using EstacolNews.Domain.NoSql.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacolNews.UseCases.NoSql.Gateway
{
    public interface IUserUseCase
    {


        Task<User> AddUser(User user);


    }
}
