﻿using EstacolNews.Domain.Sql.Entities;


namespace EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.EditorCommands
{
    public interface IEditorRepository
    {


        Task<Editor> InsertEditorAsync(Editor editor);


    }
}