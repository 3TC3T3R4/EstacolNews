using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;
using EstacolNews.Domain.Sql.Entities.Wrappers.ClientSide.Content;
using EstacolNews.Domain.Sql.Entities.Wrappers.EditorSide.Editor;
using EstacolNews.UseCases.Sql.Gateway.IterfacesUseCase.Commands;
using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.EditorCommands;
using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.PublicationCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacolNews.UseCases.Sql.UseCases
{
    public class PublicationUseCase : IPublicationUseCase
    {

        private readonly IPublicationRepository _publicationRepository;

        public PublicationUseCase(IPublicationRepository publicationRepository)
        {
            _publicationRepository =publicationRepository;
        }
        public async Task<Publication> AddPublication(Publication publication)
        {
            return await _publicationRepository.InsertPublicationAsync(publication);
        }
        public async Task<PublicationByEditor> GetAllPublicationByEditorAsync(int idEditor)
        {
            return await _publicationRepository.GetAllPublicationByEditorAsync(idEditor);
        }
        public async Task<PublicationByContent> GetAllPublicationByContentAsync(int idContent)
        {
            return await _publicationRepository.GetAllPublicationByContentAsync(idContent);
        }

    }
}
