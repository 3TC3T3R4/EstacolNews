using EstacolNews.Domain.Sql.Entities;


namespace EstacolNews.UseCases.Sql.Gateway.IterfacesUseCase.Commands
{
    public interface IEditorUseCase
    {
        Task<Editor> AddEditor(Editor editor);
        Task<List<Editor>> GetAllEditorsAsync();
        Task<Editor> GetEditorByIdAsync(int idEditor);

    }
}
