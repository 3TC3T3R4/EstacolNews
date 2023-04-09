using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;
using EstacolNews.Domain.Sql.Entities.Wrappers.EditorSide.Editor;

namespace EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.PublicationCommands
{
    public interface IPublicationRepository
    {
        Task<InsertNewPublication> InsertPublicationAsync(Publication publication);
        Task<PublicationByEditor> GetAllPublicationByEditorAsync(int idEditor);

    }
}
