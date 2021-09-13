using System;

namespace LiveTables.Domain.Models.ViewModels
{
    public class ScoresViewModel
    {
        public string HomeTeam { get; set; }
        public int HomeScore { get; set; }
        public string AwayTeam { get; set; }
        public int AwayScore { get; set; }
        public DateTime GameDate { get; set; }
    }
}