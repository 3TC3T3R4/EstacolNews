using AutoMapper;
using Dapper;
using DriverAdapterSQL.Gateway;
using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;
using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.PublicationCommands;

namespace DriverAdapterSQL.Repositories
{
   public class PublicationRepository :IPublicationRepository
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly IMapper _mapper;
        private readonly string tableName = "Publication";


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

      
    }
}
