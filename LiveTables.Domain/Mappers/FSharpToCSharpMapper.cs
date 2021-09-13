using System.Collections.Generic;
using System.Linq;
using LiveTables.Core;
using LiveTables.Domain.Models;
using LiveTables.Domain.Models.ViewModels;

namespace LiveTables.Domain.Mappers
{
    public static class FSharpToCSharpMapper
    {
        public static IEnumerable<LiveTableModelViewModel> ToScores(
            this IEnumerable<DomainTypes.ServiceTypes.LiveTableEntity> liveTableEntities) =>
            liveTableEntities.Select(entity => new LiveTableModelViewModel(entity.Team, entity.Games, entity.Wins, entity.Draws,
                entity.Loose, entity.GoalScore, entity.GoalAgainst, entity.GoalDifference, entity.TotalPoints, entity.Form));
    }
}