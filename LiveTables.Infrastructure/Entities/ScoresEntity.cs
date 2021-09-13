using System;
using System.Collections.Generic;

namespace LiveTables.Infrastructure.Entities
{
    public class ScoresEntity
    {
        public int Id { get; set; }
        public int Home { get; set; }
        public string HomeName { get; set; }
        public int Away { get; set; }
        public string AwayName { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public DateTime? FixtureDate { get; set; }
        public int LeagueId { get; set; }
        public int Season { get; set; }
        public virtual ICollection<TeamEntity> Teams { get; set; }
    }
}