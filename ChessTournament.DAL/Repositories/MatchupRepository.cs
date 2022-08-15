using ChessTournament.DAL.Context;
using ChessTournament.DAL.Interfaces;
using ChessTournament.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ChessTournament.DAL.Repositories
{
    public class MatchupRepository : RepositoryBase<Guid, Matchup>, IMatchupRepository
    {
        public MatchupRepository(ChessTournamentContext context) : base(context)
        {
        }

        /// <summary>
        /// Get the matching matchup with its tournament property laoded.
        /// </summary>
        /// <param name="id">The matchup id</param>
        /// <returns>A Matchup object containing a tournament. Null if not found.</returns>
        public Matchup? GetWithTournament(Guid id)
        {
            return _context.Matchups.Include(m => m.Tournament).FirstOrDefault(m => m.Id == id);
        }
    }
}
