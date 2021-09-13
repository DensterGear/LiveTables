using System;
using System.Collections.Generic;
using LiveTables.Domain.Models;
using LiveTables.Infrastructure.Entities;

namespace LiveTables.Api.Services
{
    public class LeagueEntityService : IEntityService<LeagueEntity>
    {
        public Result<IEnumerable<LeagueEntity>> Get(int leagueId)
        {
            throw new NotImplementedException();
        }

        public Result<LeagueEntity> GetOrAdd(LeagueEntity entity)
        {
            throw new NotImplementedException();
        }

        public Result<IEnumerable<LeagueEntity>> Filter(Func<LeagueEntity, bool> filter)
        {
            throw new NotImplementedException();
        }

        public Result Save(List<LeagueEntity> results, int resultsLeagueId)
        {
            throw new NotImplementedException();
        }
    }
}