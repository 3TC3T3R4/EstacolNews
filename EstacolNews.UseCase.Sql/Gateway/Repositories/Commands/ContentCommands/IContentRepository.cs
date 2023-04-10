using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.ContentCommands
{
    public interface IContentRepository
    {
        Task<Content> InsertContentAsync(Content content);
        Task<List<Content>> GetAllContentsAsync();
        Task<Content> GetContentByIdAsync(int idContent);
        Task<InsertNewContent> UpdateContentByIdAsync(int idContent, InsertNewContent content);
        Task<string> DeleteContentByIdAsync(int idContent);

        Task<string> LikeContentByIdAsync(int idContent);


    }
}
