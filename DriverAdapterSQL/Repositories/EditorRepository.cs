using Ardalis.GuardClauses;
using Dapper;
using DriverAdapterSQL.Gateway;
using EstacolNews.Domain.Sql.Commands;
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

            Guard.Against.Null(editor, nameof(editor));
            Guard.Against.NullOrEmpty(editor.complete_name, nameof(editor.complete_name), "No puedes continuar sin un nombre");
            //Guard.Against.NullOrEmpty(editor.phone, nameof(editor.phone));
            Guard.Against.NullOrEmpty(editor.estate.ToString(), nameof(editor.estate));

            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var editorNewAdd = new
            {
                //id = editor.id_Editor,
                idEdi= editor.id_editor,
                completeName = editor.complete_name,
               // phoneM = editor.phone,
                estateE = editor.estate

            };
            string sqlQuery = $"INSERT INTO {tableName} (id_editor,complete_name,estate)VALUES(@idEdi, @completeName,@estateE)";
            var rows = await connection.ExecuteAsync(sqlQuery, editorNewAdd);
            return editor;
        }

        public async Task<List<Editor>> GetAllEditorsAsync()
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {tableName}";
            var result = await connection.QueryAsync<Editor>(sqlQuery);
            connection.Close();
            return result.ToList();


        }

        public async Task<InsertNewEditor> GetEditorByIdAsync(string idEditor)
        {



            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {tableName} WHERE id_editor = '{idEditor}' ";
            var result = await connection.QueryFirstAsync<InsertNewEditor>(sqlQuery);
            connection.Close();
            return result;
            
        }






    }
}

