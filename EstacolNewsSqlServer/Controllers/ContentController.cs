using AutoMapper;
using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;
using EstacolNews.UseCases.Sql.Gateway;
using EstacolNews.UseCases.Sql.UseCases;
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





    }
}
