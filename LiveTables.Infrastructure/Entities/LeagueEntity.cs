namespace LiveTables.Infrastructure.Entities
{
    public class LeagueEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public LeagueType LeagueType { get; set; }
    }
}