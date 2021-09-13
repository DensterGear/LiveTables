using LiveTables.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace LiveTables.Infrastructure
{
    public class LiveTablesContext : DbContext, ILiveTablesContext
    {
        public LiveTablesContext(DbContextOptions<LiveTablesContext> options) : base(options)
        {
        }
        
        public DbSet<LeagueEntity> Leagues { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<ScoresEntity> Scores { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ScoresEntity>()
                .HasMany(property => property.Teams)
                .WithMany(property => property.Scores);
        }
    }
}