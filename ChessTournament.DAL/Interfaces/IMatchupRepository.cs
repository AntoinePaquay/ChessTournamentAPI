using ChessTournament.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.DAL.Interfaces
{
    public interface IMatchupRepository : IRepository<Guid, Matchup>
    {
        Matchup? GetWithTournament(Guid id);
    }
}
