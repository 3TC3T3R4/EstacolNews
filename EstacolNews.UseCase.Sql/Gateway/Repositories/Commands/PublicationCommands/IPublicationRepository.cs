﻿using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;


namespace EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.PublicationCommands
{
    public interface IPublicationRepository
    {
        Task<InsertNewPublication> InsertPublicationAsync(Publication publication);

    }
}