#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using LiveTables.Domain.Models;
using LiveTables.Infrastructure;
using LiveTables.Infrastructure.Entities;

namespace LiveTables.Api.Services
{
    public class ScoresEntityService : IEntityService<ScoresEntity>
    {
        private readonly ILiveTablesContext _liveTablesContext;
        private readonly IEntityService<TeamEntity> _teamEntityService;

        public ScoresEntityService(ILiveTablesContext liveTablesContext, IEntityService<TeamEntity> teamEntityService)
        {
            _liveTablesContext = liveTablesContext ?? throw new ArgumentNullException(nameof(liveTablesContext));
            _teamEntityService = teamEntityService ?? throw new ArgumentNullException(nameof(teamEntityService));
        }

        public Result<IEnumerable<ScoresEntity>> Get(int leagueId)
        {
            var league = GetLeague(leagueId);
            if (league == null)
            {
                return new Result<IEnumerable<ScoresEntity>>
                {
                    IsError = true,
                    ErrorValue =
                        new ValidationError(
                            $"League with id {leagueId} not exists. First you should add the league data")
                };
            }

            return new Result<IEnumerable<ScoresEntity>>
            {
                IsError = false,
                ResultValue = _liveTablesContext.Scores
            };
        }

        public Result<ScoresEntity> GetOrAdd(ScoresEntity entity)
        {
            var savedEntity = Save(new List<ScoresEntity>
            {
                entity
            }, entity.LeagueId);

            if (savedEntity.IsSuccess)
            {
                return new Result<ScoresEntity>
                {
                    IsError = false,
                    ResultValue = entity
                };
            }

            return new Result<ScoresEntity>
            {
                IsError = true,
                ErrorValue = new SystemError(savedEntity.ErrorValue.ErrorMessage)
            };
        }

        public Result<IEnumerable<ScoresEntity>> Filter(Func<ScoresEntity, bool> filter) =>
            new()
            {
                IsError = false,
                ResultValue = _liveTablesContext.Scores
                    .Where(filter)
            };

        public Result Save(List<ScoresEntity> results, int leagueId)
        {
            var league = GetLeague(leagueId);
            if (league == null)
            {
                return new Result
                {
                    IsError = true,
                    ErrorValue =
                        new ValidationError(
                            $"League with id {leagueId} not exists. First you should add the league data")
                };
            }

            var existingScores = GetExistingScores(results);
            results.Except(existingScores)
                .ToList()
                .ForEach(score =>
                {
                    var homeTeam = _teamEntityService.GetOrAdd(new TeamEntity
                    {
                        Name = score.HomeName
                    });

                    var awayTeam = _teamEntityService.GetOrAdd(new TeamEntity
                    {
                        Name = score.HomeName
                    });

                    if (!homeTeam.IsSuccess || !awayTeam.IsSuccess) return;

                    score.Home = homeTeam.ResultValue.Id;
                    score.Away = awayTeam.ResultValue.Id;
                    _liveTablesContext.Scores.Add(score);
                });

            _liveTablesContext.SaveChanges();

            return new Result
            {
                IsError = false
            };
        }

        private IEnumerable<ScoresEntity> GetExistingScores(IEnumerable<ScoresEntity> results) =>
            _liveTablesContext.Scores.Join(results,
                    result => new Tuple<int, int, int, DateTime?>(result.LeagueId, result.Home, result.Away,
                        result.FixtureDate).ToValueTuple(),
                    entity => new Tuple<int, int, int, DateTime?>(entity.LeagueId, entity.Home, entity.Away,
                        entity.FixtureDate).ToValueTuple(),
                    (result, entity) => result)
                .ToList();

        private LeagueEntity? GetLeague(int resultsLeagueId) =>
            _liveTablesContext.Leagues.FirstOrDefault(league => league.Id == resultsLeagueId);
    }
}