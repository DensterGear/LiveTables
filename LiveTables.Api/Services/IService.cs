using System.Collections.Generic;
using LiveTables.Domain.Models;

namespace LiveTables.Api.Services
{
    public interface IService<TEntity>
    {
        Result<IEnumerable<TEntity>> Get(int leagueId);
    }
}