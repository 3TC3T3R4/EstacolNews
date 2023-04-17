using EstacolNews.Domain.NoSql.Entities;


namespace EstacolNews.UseCases.NoSql.Gateway.Repositories.Commands
{
    public interface IUserRepository
    {


        Task<User> InsertUserAsync(User user);
        Task<User> GetUserByIdAsync(string id);




    }
}
