using AutoMapper;
using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;
using EstacolNews.UseCases.Sql.Gateway;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstacolNewsSqlServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {
        private readonly IPublicationUseCase _publicationUseCase;
        private readonly IMapper _mapper;


        public PublicationController(IPublicationUseCase publicationUseCase, IMapper mapper)
        {
            _publicationUseCase = publicationUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<InsertNewPublication> Create_Publication([FromBody] InsertNewPublication command)
        {
            return await _publicationUseCase.AddPublication(_mapper.Map<Publication>(command));
        }

    }
}
