using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;


namespace EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.EditorCommands
{
    public interface IEditorRepository
    {


        Task<Editor> InsertEditorAsync(Editor editor);
        Task<List<Editor>> GetAllEditorsAsync();

        Task<InsertNewEditor> GetEditorByIdAsync(string idEditor);

    }
}
