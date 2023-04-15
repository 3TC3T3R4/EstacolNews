using Ardalis.GuardClauses;
using Dapper;
using DriverAdapterSQL.Gateway;
using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;
using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.ContentCommands;


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
            var result = data.Where(x => x.estate_process == "Editando" && x.estate !=false).ToList();
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

            Guard.Against.Null(content, nameof(content));
            Guard.Against.NullOrEmpty(content.title, nameof(content.title), "NO PUEDES CREAR ALGO NUEVO SIN UN TITULO");

            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var contentNewAdd = new
            {

                titleB = content.title,
                estateProcess = "Editando",
                estateB = content.estate,
                keywordsB = content.keywords,
                type = content.type_publication,
                urlB = "https://localhost:7267/api/Content/",
                finishdateB = content.finish_date,
                publicationdateB = content.publication_date,
                startdate = content.program_date,
                numberCollaborators = 0,
                likes = 0,
                dislikes = 0,
                number_of_Share = 0,
                descriptionB = content.description
            };
            string sqlQuery = $"INSERT INTO {tableName} (title,estate_process,estate,keywords,type_publication,url,finish_date,publication_date,program_date,number_of_collaborators,likes,dislikes,number_of_Share,description)VALUES(@titleB,@estateProcess,@estateB,@keywordsB,@type,@urlB,@finishdateB,@publicationdateB,@startdate,@numberCollaborators,@likes,@dislikes,@number_of_Share,@descriptionB)";
            var rows = await connection.ExecuteAsync(sqlQuery, contentNewAdd);
            return content;
        }

        public async Task<InsertNewContent> UpdateContentByIdAsync(int idContent, InsertNewContent content)

        {

            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"UPDATE {tableName} SET title = @title,keywords = @keywords,finish_date = @finish_date,publication_date = @publication_date,program_date = @program_date,description = @description WHERE id_content = {idContent}";
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

        public async Task<string> LikeContentByIdAsync(int idContent)
        {
            //var param = new { like = 1 };
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"UPDATE {tableName} SET  likes = likes + 1 WHERE  id_content = {idContent}";
            var result = await connection.ExecuteAsync(sqlQuery);
            connection.Close();
            return "Like successfully";
        }


        public async Task<string> UpdateUrlByIdAsync(int idContent)
        {
            var paramUrl = new { 
                
                defaultUrl = "https://localhost:7267/api/Content/" + $"{idContent}" 
            };

            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"UPDATE {tableName} SET  url = @defaultUrl WHERE  id_content = {idContent}";
            var result = await connection.ExecuteAsync(sqlQuery,paramUrl);
            connection.Close();
            return "Update URL  successfully";
        }



    }
}
