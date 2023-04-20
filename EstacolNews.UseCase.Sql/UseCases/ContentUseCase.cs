using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;
using EstacolNews.UseCases.Sql.Gateway.IterfacesUseCase.Commands;

using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.ContentCommands;
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

        public async Task<List<Content>> GetAllContentsAsync()
        {
            return await _contentRepository.GetAllContentsAsync();
        }
        public async Task<List<Content>> GetAllContentsAsyncClient()
        {
            return await _contentRepository.GetAllContentsAsyncClient();
        }


        public async Task<Content> GetContentByIdAsync(int idContent)
        {
            return await _contentRepository.GetContentByIdAsync(idContent);
        }

        public async Task<InsertNewContent> UpdateContentByIdAsync(int idContent, InsertNewContent content)
        {
            return await _contentRepository.UpdateContentByIdAsync(idContent, content);
        }

        public async Task<string> DeleteContentByIdAsync(int idContent)
        {
            return await _contentRepository.DeleteContentByIdAsync(idContent);
        }
        public async Task<string> LikeContentByIdAsync(int idContent)
        {
            return await _contentRepository.LikeContentByIdAsync(idContent);
        }
        public async Task<string>UpdateUrlByIdAsync(int idContent)
        {
            return await _contentRepository.UpdateUrlByIdAsync(idContent);
        }

    }

}
