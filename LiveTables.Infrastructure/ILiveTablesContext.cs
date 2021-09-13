using LiveTables.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace LiveTables.Infrastructure
{
    public interface ILiveTablesContext
    {
        public DbSet<LeagueEntity> Leagues { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<ScoresEntity> Scores { get; set; }

        int SaveChanges();
    }
}