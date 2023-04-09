using AutoMapper;
using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;
using EstacolNews.UseCases.Sql.Gateway.IterfacesUseCase.Commands;
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

        [HttpGet]
        public async Task<List<Editor>> Get_List_Editors()
        {
            return await _editorUseCase.GetAllEditorsAsync();
        }



        [HttpGet("{id:int}")]
        public async Task<Editor> Get_Editor_By_Id(int id)
        {
            return await _editorUseCase.GetEditorByIdAsync(id);
        }






    }
}
