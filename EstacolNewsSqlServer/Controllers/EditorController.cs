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
        public async Task<Editor> Create_User([FromBody] InsertNewEditor command)
        {
            return await _editorUseCase.AddUser(_mapper.Map<Editor>(command));
        }






    }
}
