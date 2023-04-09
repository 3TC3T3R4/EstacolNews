using Dapper;
using DriverAdapterSQL.Gateway;
using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;
using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.ContentCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverAdapterSQL.Repositories
{
    public  class ContentRepository : IContentRepository
    {

        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly string tableName = "Content";


        public ContentRepository(IDbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }


        public async Task<List<Content>> GetAllContentsAsync()
        {
            var data = await GetAllContentsAsyncFilter();
            var result = data.Where(x => x.estate_process == "Publicado" && x.estate !=false).ToList();
            return result;
        }


        public async Task<List<Content>> GetAllContentsAsyncFilter()
        {


            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {tableName}";
            var result = await connection.QueryAsync<Content>(sqlQuery);
            connection.Close();
            return result.ToList();


        }

        public async  Task<Content> GetContentByIdAsync(int idContent)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT title FROM {tableName} WHERE id_content = {idContent}";
            var result = await connection.QueryFirstAsync<Content>(sqlQuery);
            connection.Close();
            return result;
        }

        public async Task<Content> InsertContentAsync(Content content)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var contentNewAdd = new
            {
                
                titleB= content.title,
                estateProcess = content.estate_process,
                estateB= content.estate,
                keywordsB = content.keywords,
                type = content.type_publication,
                urlB = content.url,
                finishdateB = content.finish_date,
                publicationdateB = content.publication_date,
                startdate = content.program_date,
                numberCollaborators = content.number_of_collaborators
            };
            string sqlQuery = $"INSERT INTO {tableName} (title,estate_process,estate,keywords,type_publication,url,finish_date,publication_date,program_date,number_of_collaborators)VALUES(@titleB,@estateProcess,@estateB,@keywordsB,@type,@urlB,@finishdateB,@publicationdateB,@startdate,@numberCollaborators)";
            var rows = await connection.ExecuteAsync(sqlQuery, contentNewAdd);
            return content;
        }

        public async Task<InsertNewContent> UpdateContentByIdAsync(int idContent, InsertNewContent content)

        {

            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"UPDATE {tableName} SET title = @title,estate_process = @estate_process,keywords = @keywords,type_publication = @type_publication,finish_date = @finish_date,publication_date = @publication_date,program_date = @program_date,number_of_collaborators = @number_of_collaborators WHERE id_content = {idContent}";
            var rows = await connection.ExecuteAsync(sqlQuery, content);
            return content;
        }

        public async Task<string> DeleteContentByIdAsync(int idContent)
        {
            var param  =  new { delete = 0}; 
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"UPDATE {tableName} SET  estate = @delete WHERE  id_content = {idContent}";
            var result = await connection.ExecuteAsync(sqlQuery, param);
            connection.Close();
            return "ConentDelted";
        }

    }
}
