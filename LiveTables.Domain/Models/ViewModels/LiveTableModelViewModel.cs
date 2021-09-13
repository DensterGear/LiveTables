namespace LiveTables.Domain.Models.ViewModels
{
    public class LiveTableModelViewModel
    {
        public LiveTableModelViewModel(string teamName, int games, int wins, int draws, int loose, int goalScore, int goalAgainst,
            int goalDifference, int totalPoints, string form)
        {
            TeamName = teamName;
            Games = games;
            Wins = wins;
            Draws = draws;
            Loose = loose;
            GoalScore = goalScore;
            GoalAgainst = goalAgainst;
            GoalDifference = goalDifference;
            TotalPoints = totalPoints;
            Form = form;
        }

        public string TeamName { get; }
        public int Games { get; }
        public int Wins { get; }
        public int Draws { get; }
        public int Loose { get; }
        public int GoalScore { get; }
        public int GoalAgainst { get; }
        public int GoalDifference { get; }
        public int TotalPoints { get; }
        public string Form { get; }
    }
}