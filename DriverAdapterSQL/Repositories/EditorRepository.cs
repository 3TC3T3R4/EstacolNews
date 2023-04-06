using Dapper;
using DriverAdapterSQL.Gateway;
using EstacolNews.Domain.Sql.Entities;
using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.EditorCommands;

namespace DriverAdapterSQL.Repositories
{
    public class EditorRepository : IEditorRepository
    {

        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly string tableName = "Editor";


        public EditorRepository(IDbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }

        public async Task<Editor> InsertEditorAsync(Editor editor)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var editorNewAdd = new
            {
                //id = editor.id_Editor,
                idUser = editor.id_user,
                completeName = editor.complete_name,
                phoneM = editor.phone,
                estateE = editor.estate

            };
            string sqlQuery = $"INSERT INTO {tableName} (id_user,complete_name,phone,estate)VALUES(@idUser, @completeName, @phoneM,@estateE)";
            var rows = await connection.ExecuteAsync(sqlQuery, editorNewAdd);
            return editor;
        }



    }
}

