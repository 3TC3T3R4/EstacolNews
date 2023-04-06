using EstacolNews.Domain.Sql.Entities;
using EstacolNews.UseCases.Sql.Gateway;
using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.ContentCommands;
using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.EditorCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacolNews.UseCases.Sql.UseCases
{
    public class ContentUseCase : IContentUseCase
    {

        private readonly IContentRepository _contentRepository;

        public ContentUseCase(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }



        public async Task<Content> AddContent(Content content)
        {
            return await _contentRepository.InsertContentAsync(content);
        }
    }
}
