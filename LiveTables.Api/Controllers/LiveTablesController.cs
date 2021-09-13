using System;
using System.Linq;
using LiveTables.Api.Services;
using LiveTables.Domain.Models.ViewModels;
using LiveTables.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LiveTables.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveTablesController : ControllerBase
    {
        private readonly IEntityService<ScoresEntity> _scoreEntityService;

        public LiveTablesController(IEntityService<ScoresEntity> scoreEntityService)
        {
            _scoreEntityService = scoreEntityService ?? throw new ArgumentNullException(nameof(scoreEntityService));
        }

        [HttpGet]
        [Route("ImportData")]
        public IActionResult Import([FromBody] ResultsViewModel results)
        {
            if (results == null || !results.Scores.Any())
            {
                return BadRequest("Required data is missing");
            }

            var scoresDto = results.Scores.Select(score => new ScoresEntity
            {
                HomeName = score.HomeTeam,
                AwayName = score.AwayTeam,
                Home = score.HomeScore,
                Away = score.AwayScore,
                FixtureDate = score.GameDate,
                LeagueId = results.LeagueId,
                Season = score.GameDate.Year
            }).ToList();

            var importResult = _scoreEntityService.Save(scoresDto, results.LeagueId);
            return importResult.IsError ? BadRequest(importResult.ErrorValue.ErrorMessage) : Ok();
        }
    }
}