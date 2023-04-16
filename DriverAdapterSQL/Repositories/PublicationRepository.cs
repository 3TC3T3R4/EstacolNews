using AutoMapper;
using Dapper;
using DriverAdapterSQL.Gateway;
using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;
using EstacolNews.Domain.Sql.Entities.Wrappers.ClientSide.Content;
using EstacolNews.Domain.Sql.Entities.Wrappers.ClientSide.Publication;
using EstacolNews.Domain.Sql.Entities.Wrappers.EditorSide.Editor;
using EstacolNews.Domain.Sql.Entities.Wrappers.EditorSide.Publication;
using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.PublicationCommands;
using Microsoft.IdentityModel.Tokens;

namespace DriverAdapterSQL.Repositories
{
    public class PublicationRepository : IPublicationRepository
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly IMapper _mapper;
        private readonly string tableName = "Publication";
        private readonly string tableNameE = "Editor";
        private readonly string tableNameC = "Content";




        public PublicationRepository(IDbConnectionBuilder dbConnectionBuilder, IMapper mapper)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
            _mapper = mapper;
        }

        public async Task<Publication> InsertPublicationAsync(Publication publication)
        {

            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var contentNewAdd = new
            {
                id_edi = publication.id_editor_publication,
                id_cont = publication.id_content_publication,
                estateB = publication.estate
                
            };
            string sqlQuery = $"INSERT INTO {tableName} (id_editor_publication,id_content_publication,estate)VALUES(@id_edi,@id_cont,@estateB)";

            var rows = await connection.ExecuteAsync(sqlQuery, contentNewAdd);
            
            return publication;
        }

        public async Task<PublicationByEditor> GetAllPublicationByEditorAsync(int id)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {tableNameE} edi " +
                                $"INNER JOIN Publication pu ON pu.id_editor_publication = @id " +
                                $"INNER JOIN Content c ON c.id_content = pu.id_content_publication " +
                                $"WHERE edi.id_editor = @id";

            var customerAll = new PublicationByEditor();
            var customer = await connection.QueryAsync<PublicationByEditor, PublicationsWithContents,
                Content, PublicationByEditor>(sqlQuery, (c, ac, card) =>
                {
                    
                    customerAll.Publications.Add(ac);
                    ac.Content.Add(card) ;

                    return c;
                },
            new { id },
            splitOn: "id_publication, id_content");

            if (customer.IsNullOrEmpty())
            {
                throw new Exception("The publication doesn't exist or doesn't have an account or card assigned.");
            }
            connection.Close();
            return customerAll;

        }


        public async Task<PublicationByContent> GetAllPublicationByContentAsync(int id)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {tableNameC} co " +
                                $"INNER JOIN Publication pu ON pu.id_content_publication = @id " +
                                $"INNER JOIN Editor edi ON edi.id_editor = pu.id_editor_publication " +
                                $"WHERE co.id_content = @id";

            var customerAll = new PublicationByContent();
            var customer = await connection.QueryAsync<PublicationByContent, PublicationWithEditors,
                Editor, PublicationByContent>(sqlQuery, (c, ac, card) =>
                {

                    customerAll.Publications.Add(ac);
                    ac.Editor.Add(card);

                    return c;
                },
            new { id },
            splitOn: "id_publication, id_editor");

            if (customer.IsNullOrEmpty())
            {
                throw new Exception("The publication doesn't exist or doesn't have an account or card assigned.");
            }
            connection.Close();
            return customerAll;

        }

        public async Task<string> UpdateStateByIdAsync(int id)
        {
           
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"UPDATE  {tableNameC}  SET estate_process = 'Publicado' " +
                                $"WHERE id_content = {id}";

            var rows = await connection.ExecuteAsync(sqlQuery);
            
            connection.Close();
            return "StateUpdated";

        }




    }
}