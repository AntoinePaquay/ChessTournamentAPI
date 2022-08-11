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
    public class RepositoryTournament : RepositoryBase<Guid, Tournament>, ITournamentRepository
    {
        public RepositoryTournament(ChessTournamentContext context) : base(context)
        {

        }

        public bool IsPlayerSignedUp(Guid tournamentId, Guid MemberId)
        {
            Tournament t = _context.Tournaments.FirstOrDefault(t => t.Id == tournamentId);
            if (t is null) return false;

            return t.Members.Any<Member>(m => m.Id == MemberId);
        }

        public int GetSignUpCount(Guid tournamentId)
        {
            Tournament t = _context.Tournaments.FirstOrDefault(t => t.Id == tournamentId);
            if (t is null) return 0;

            return t.Members.Count();
        }
    }
}
