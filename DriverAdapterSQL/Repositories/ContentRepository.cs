using Dapper;
using DriverAdapterSQL.Gateway;
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

        public async Task<Content> InsertContentAsync(Content content)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var contentNewAdd = new
            {
                
                titleB= content.title,
                estateB= content.estate,
                keywordsB = content.keywords
            };
            string sqlQuery = $"INSERT INTO {tableName} (title,estate,keywords)VALUES(@titleB, @estateB, @keywordsB)";
            var rows = await connection.ExecuteAsync(sqlQuery, contentNewAdd);
            return content;
        }




    }
}
