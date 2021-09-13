using System;
using System.Collections.Generic;
using System.Linq;
using LiveTables.Domain.Models;
using LiveTables.Infrastructure;
using LiveTables.Infrastructure.Entities;

namespace LiveTables.Api.Services
{
    public class TeamEntityService : IEntityService<TeamEntity>
    {
        private readonly ILiveTablesContext _liveTablesContext;

        public TeamEntityService(ILiveTablesContext liveTablesContext)
        {
            _liveTablesContext = liveTablesContext ?? throw new ArgumentNullException(nameof(liveTablesContext));
        }

        public Result<IEnumerable<TeamEntity>> Get(int leagueId)
        {
            throw new NotImplementedException();
        }

        public Result<TeamEntity> GetOrAdd(TeamEntity entity)
        {
            var existingTeam = _liveTablesContext.Teams
                .FirstOrDefault(team => team.Name == entity.Name);

            if (existingTeam != null)
            {
                return new Result<TeamEntity>
                {
                    IsError = false,
                    ResultValue = existingTeam
                };
            }

            var addedTeam = _liveTablesContext.Teams.Add(new TeamEntity
            {
                Name = entity.Name
            });

            return new Result<TeamEntity>
            {
                IsError = false,
                ResultValue = addedTeam.Entity
            };
        }

        public Result<IEnumerable<TeamEntity>> Filter(Func<TeamEntity, bool> filter)
        {
            var teams = _liveTablesContext.Teams
                .Where(filter)
                .ToList();
            if (teams.Any())
            {
                return new Result<IEnumerable<TeamEntity>>
                {
                    IsError = false,
                    ResultValue =  _liveTablesContext.Teams
                        .Where(filter)
                        .ToList()
                };
            }
            
            return new Result<IEnumerable<TeamEntity>>
            {
                IsError = true
            };
        }

        public Result Save(List<TeamEntity> results, int resultsLeagueId)
        {
            throw new NotImplementedException();
        }
    }
}