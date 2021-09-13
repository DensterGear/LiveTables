using System.Collections.Generic;
using LiveTables.Domain.Models;
using LiveTables.Domain.Models.ViewModels;

namespace LiveTables.Api.Services
{
    public class LiveTablesService : IService<LiveTableModelViewModel>
    {
        public Result<IEnumerable<LiveTableModelViewModel>> Get(int leagueId)
        {
            throw new System.NotImplementedException();
        }
    }
}