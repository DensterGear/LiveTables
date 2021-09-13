using System.Collections.Generic;

namespace LiveTables.Infrastructure.Entities
{
    public class TeamEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ScoresEntity> Scores { get; set; }
    }
}