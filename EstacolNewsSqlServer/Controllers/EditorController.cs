using AutoMapper;
using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;
using EstacolNews.UseCases.Sql.Gateway;
using Microsoft.AspNetCore.Mvc;

namespace EstacolNewsSqlServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorController : ControllerBase
    {

        private readonly IEditorUseCase _editorUseCase;
        private readonly IMapper _mapper;


        public EditorController(IEditorUseCase editorUseCase, IMapper mapper)
        {
            _editorUseCase = editorUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<Editor> Create_Editor([FromBody] InsertNewEditor command)
        {
            return await _editorUseCase.AddEditor(_mapper.Map<Editor>(command));
        }






    }
}
