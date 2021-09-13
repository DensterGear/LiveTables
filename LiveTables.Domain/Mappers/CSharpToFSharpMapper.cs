using System.Collections.Generic;
using System.Linq;
using LiveTables.Core;
using LiveTables.Infrastructure.Entities;
using Microsoft.FSharp.Collections;

namespace LiveTables.Domain.Mappers
{
    public static class CSharpToFSharpMapper
    {
        public static FSharpList<DomainTypes.ServiceTypes.Score> ToScores(this IEnumerable<ScoresEntity> scoresDto) =>
            ListModule.OfSeq(scoresDto
                .Where(score => score.HomeScore != null && score.AwayScore != null)
                .Select(score =>
                    new DomainTypes.ServiceTypes.Score(score.Home, score.HomeName, score.Away, score.AwayName, score.HomeScore.Value,
                        score.AwayScore.Value)));
    }
}