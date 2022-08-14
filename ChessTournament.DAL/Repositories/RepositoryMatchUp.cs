using ChessTournament.DAL.Context;
using ChessTournament.DAL.Interfaces;
using ChessTournament.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.DAL.Repositories
{
    public class RepositoryMatchUp : RepositoryBase<Guid, Matchup>, IMatchupRepository
    {
        public RepositoryMatchUp(ChessTournamentContext context) : base(context)
        {
        }
        public void Add(IEnumerable<Matchup> matches)
        {
            foreach (var item in matches)
            {
                this.Create(item);
            }

            if (_context.SaveChanges() == 0) throw new Exception($"Couldn't add the {matches.Count()} matchups");
            
        }
    }
}
