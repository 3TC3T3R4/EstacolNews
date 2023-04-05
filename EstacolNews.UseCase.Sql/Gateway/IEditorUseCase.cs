using EstacolNews.Domain.Sql.Entities;


namespace EstacolNews.UseCases.Sql.Gateway
{
    public interface IEditorUseCase
    {
        Task<Editor> AddEditor(Editor editor);

    }
}
