using System.Collections.Generic;

namespace LiveTables.Domain.Models.ViewModels
{
    public class ResultsViewModel
    {
        public int LeagueId { get; set; }
        
        public IEnumerable<ScoresViewModel> Scores { get; set; }
    }
}