using ChessTournament.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.DAL.Interfaces
{
    public interface IMatchupRepository 
    {
        void Add(IEnumerable<Matchup> matches);
    }
}
