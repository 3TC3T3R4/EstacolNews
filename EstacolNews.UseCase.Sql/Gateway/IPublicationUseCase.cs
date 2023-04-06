using EstacolNews.Domain.Sql.Commands;
using EstacolNews.Domain.Sql.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacolNews.UseCases.Sql.Gateway
{
   public interface IPublicationUseCase
    {


        Task<InsertNewPublication> AddPublication(Publication publication);

    }
}
