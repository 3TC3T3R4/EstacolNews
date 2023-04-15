using AutoMapper;
using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;
using EstacolNews.UseCases.Sql.Gateway.IterfacesUseCase.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstacolNewsSqlServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContentUseCase _contentUseCase;
        private readonly IMapper _mapper;

        public ContentController(IContentUseCase contentUseCase, IMapper mapper)
        {
            _contentUseCase = contentUseCase;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<Content> Create_Content([FromBody] InsertNewContent command)
        {
            return await _contentUseCase.AddContent(_mapper.Map<Content>(command));
        }

        [HttpGet]
        public async Task<List<Content>> Get_List_Contents()
        {
            return await _contentUseCase.GetAllContentsAsync();
        }



        [HttpGet("{id:int}")]

        public async Task<Content> Get_Content_By_Id(int id)
        {
            return await _contentUseCase.GetContentByIdAsync(id);
        }



        [HttpPut]
        public async Task<InsertNewContent> Update_Content_By_Id(int id, [FromBody] InsertNewContent command)
        {
            return await _contentUseCase.UpdateContentByIdAsync( id, command);
        }

        [HttpPut("{id:int}")]
        public async Task<string> Delete_Content_By_Id(int id)
        {
            return await _contentUseCase.DeleteContentByIdAsync(id);
        }


        [HttpPut("LikeContent")]
        public async Task<string> Like_Content(int idContent)
        {
            return await _contentUseCase.LikeContentByIdAsync(idContent);
        }
        [HttpPut("UpdateUrl")]
        public async Task<string> Update_Url(int idContent)
        {
            return await _contentUseCase.UpdateUrlByIdAsync(idContent);
        }





    }
}
