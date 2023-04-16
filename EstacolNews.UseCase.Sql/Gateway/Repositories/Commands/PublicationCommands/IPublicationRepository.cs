using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;
using EstacolNews.Domain.Sql.Entities.Wrappers.ClientSide.Content;
using EstacolNews.Domain.Sql.Entities.Wrappers.EditorSide.Editor;

namespace EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.PublicationCommands
{
    public interface IPublicationRepository
    {
        Task<Publication> InsertPublicationAsync(Publication publication);
        Task<PublicationByEditor> GetAllPublicationByEditorAsync(int idEditor);
        Task<PublicationByContent> GetAllPublicationByContentAsync(int idContent);

        Task<string> UpdateStateByIdAsync(int idContent);

    }
}
