using ChessTournament.DAL.Context;
using ChessTournament.DAL.Interfaces;
using ChessTournament.DL.Entities;
using ChessTournament.DL.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace ChessTournament.DAL.Repositories
{
    public class RepositoryTournament : RepositoryBase<Guid, Tournament>, ITournamentRepository
    {
        public RepositoryTournament(ChessTournamentContext context) : base(context)
        {

        }

        public IEnumerable<Tournament> LastTenTournamentUpdated()
        {
            return _context.Set<Tournament>()
                .Where(t => t.Status != TournamentStatus.Finished)
                .OrderByDescending(t => t.Update)
                .Take(10);
        }
        public bool IsPlayerSignedUp(Guid tournamentId, Guid MemberId)
        {
            Tournament? t = _context.Tournaments.Include(t => t.Members).FirstOrDefault(t => t.Id == tournamentId);
            if (t is null) return false;

            return t.Members.Any<Member>(m => m.Id == MemberId);
        }

        public int GetSignUpCount(Guid tournamentId)
        {
            return _context.Tournaments.Include(t => t.Members).FirstOrDefault(t => t.Id == tournamentId)?.Members.Count() 
                ?? throw new KeyNotFoundException();
        }

        public void SignUserUp(Guid tournamentId, Guid memberId)
        {
            if (!_context.Tournaments.Any(t => t.Id == tournamentId)) throw new ArgumentException("Tournament doesn't exist");
            if (!_context.Members.Any(m => m.Id == memberId)) throw new ArgumentException("Member doesn't exist");

            _context.Tournaments.Include(t => t.Members).FirstOrDefault(t => t.Id == tournamentId)?.Members.Add(_context.Members.Find(memberId));
            _context.SaveChanges();
        }
    }
}
