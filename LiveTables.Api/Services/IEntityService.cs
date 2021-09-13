using System;
using System.Collections.Generic;
using LiveTables.Domain.Models;

namespace LiveTables.Api.Services
{
    public interface IEntityService<TEntity> : IService<TEntity>
    {
        Result<TEntity> GetOrAdd(TEntity entity);
        
        Result<IEnumerable<TEntity>> Filter(Func<TEntity, bool> filter);

        Result Save(List<TEntity> results, int leagueId);
    }
}