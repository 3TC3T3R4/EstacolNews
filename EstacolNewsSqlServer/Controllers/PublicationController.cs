using AutoMapper;
using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;
using EstacolNews.Domain.Sql.Entities.Wrappers.ClientSide.Content;
using EstacolNews.Domain.Sql.Entities.Wrappers.EditorSide.Editor;
using EstacolNews.UseCases.Sql.Gateway.IterfacesUseCase.Commands;
using EstacolNews.UseCases.Sql.UseCases;
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
        public async Task<Publication> Create_Publication([FromBody] InsertNewPublication command)
        {
            return await _publicationUseCase.AddPublication(_mapper.Map<Publication>(command));
        }

        [HttpGet]
        public async Task<PublicationByEditor> Get_PublicationByEditor(int idEditor)
        {
            return await _publicationUseCase.GetAllPublicationByEditorAsync(idEditor);
        }

        [HttpGet("GetPublicationWithEditor")]
        public async Task<PublicationByContent> Get_PublicationByContent(int idContent)
        {
            return await _publicationUseCase.GetAllPublicationByContentAsync(idContent);
        }
        [HttpPut("UpdateEstate")]
        public async Task<string> UpdateStateByContent(int idContent)
        {
            return await _publicationUseCase.UpdateStateByIdAsync(idContent);
        }


    }
}
