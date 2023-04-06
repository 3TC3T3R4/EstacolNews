using EstacolNews.Domain.Sql.Entities;
using EstacolNews.UseCases.Sql.Gateway;
using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.EditorCommands;

namespace EstacolNews.UseCases.Sql.UseCases
{
    public class EditorUseCase : IEditorUseCase
    {


        private readonly IEditorRepository _editorRepository;

        public EditorUseCase(IEditorRepository editorRepository)
        {
            _editorRepository = editorRepository;
        }
        public async Task<Editor> AddEditor(Editor editor)
        {
            return await _editorRepository.InsertEditorAsync(editor);
        }
    }
}
