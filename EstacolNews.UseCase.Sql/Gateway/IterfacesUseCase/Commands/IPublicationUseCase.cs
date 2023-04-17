using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;
using EstacolNews.Domain.Sql.Entities.Wrappers.ClientSide.Content;
using EstacolNews.Domain.Sql.Entities.Wrappers.EditorSide.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacolNews.UseCases.Sql.Gateway.IterfacesUseCase.Commands
{
    public interface IPublicationUseCase
    {


        Task<Publication> AddPublication(Publication publication);
        Task<PublicationByEditor> GetAllPublicationByEditorAsync(string idEditor);
        Task<PublicationByContent> GetAllPublicationByContentAsync(int idContent);

        Task<string> UpdateStateByIdAsync(int idContent);


    }
}
