using AutoMapper;
using Dapper;
using DriverAdapterSQL.Gateway;
using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;
using EstacolNews.Domain.Sql.Entities.Wrappers.EditorSide.Editor;
using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.PublicationCommands;
using Microsoft.IdentityModel.Tokens;

namespace DriverAdapterSQL.Repositories
{
   public class PublicationRepository :IPublicationRepository
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

        public async Task<InsertNewPublication> InsertPublicationAsync(Publication publication)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            ////verify that customer exist
            //var customerSql = $"SELECT COUNT(*) FROM Customers WHERE Customer_id = @idCustomer;";
            //var customerCount = await connection.ExecuteScalarAsync<int>(customerSql, new { idCustomer = account.Id_Customer });

            //if (customerCount == 0)
            //{
            //    throw new Exception("The customer doesn't exist.");
            //}

            var publicationToCreate = new Publication
            {
                id_editor_publication = publication.id_editor_publication,
                id_content_publication = publication.id_content_publication,
                author = publication.author,
                estate = publication.estate

            };


            //Account.Validate(accountToCreate);

            var sql = $"INSERT INTO {tableName} (id_editor_publication, id_content_publication, author, estate) " +
                $"VALUES (@id_editor_publication, @id_content_publication, @author, @estate);";

            var result = await connection.ExecuteScalarAsync(sql, publicationToCreate);
            connection.Close();
            return _mapper.Map<InsertNewPublication>(publicationToCreate);
        }

        public async Task<PublicationByEditor> GetAllPublicationByEditorAsync(int id)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {tableNameC} co " +
                                $"INNER JOIN Publication pu ON pu.id_content_publication = co.id_content " +
                                $"INNER JOIN Editor edi ON edi.id_editor = pu.id_editor_publication " +
                                $"WHERE edi.id_editor = @id";


            var publicationAll = new PublicationByEditor();
            var publication = await connection.QueryAsync<PublicationByEditor,Editor,
                Content, PublicationByEditor>(sqlQuery, (pbe,e, c) =>
                {
                    publicationAll.Contents.Add(c);
                    return pbe;
                },
            new { id },
            splitOn: "id_editor, id_content");
            if (publication.IsNullOrEmpty())
            {
                throw new Exception("The publication doesn't exist or doesn't have an content or editor assigned.");
            }
            connection.Close();
            return publicationAll;


        }

    }
}
