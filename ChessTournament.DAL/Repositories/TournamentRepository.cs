using ChessTournament.DAL.Context;
using ChessTournament.DAL.Interfaces;
using ChessTournament.DL.Entities;
using ChessTournament.DL.Enumerations;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ChessTournament.DAL.Repositories
{
    public class TournamentRepository : RepositoryBase<Guid, Tournament>, ITournamentRepository
    {
        public TournamentRepository(ChessTournamentContext context) : base(context)
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
            Tournament? t = GetWithMembers(tournamentId);
            if (t is null) return false;

            return t.Members.Any<Member>(m => m.Id == MemberId);
        }

        public int GetSignUpCount(Guid tournamentId)
        {
            return GetWithMembers(tournamentId)?.Members.Count 
                ?? throw new KeyNotFoundException();
        }

        public void SignUserUp(Guid tournamentId, Guid memberId)
        {
            if (!_context.Tournaments.Any(t => t.Id == tournamentId)) throw new ArgumentException("Tournament doesn't exist");
            if (!_context.Members.Any(m => m.Id == memberId)) throw new ArgumentException("Member doesn't exist");

            _context.Tournaments.Include(t => t.Members).FirstOrDefault(t => t.Id == tournamentId)?.Members.Add(_context.Members.Find(memberId));
            _context.SaveChanges();
        }

        public void WithdrawUser(Guid tournamentId, Guid memberId)
        {
            if (!_context.Tournaments.Any(t => t.Id == tournamentId)) throw new ArgumentException("Tournament doesn't exist");
            if (!_context.Members.Any(m => m.Id == memberId)) throw new ArgumentException("Member doesn't exist");

            _context.Tournaments.Include(t => t.Members).FirstOrDefault(t => t.Id == tournamentId)?.Members.Remove(_context.Members.Find(memberId));
            _context.SaveChanges();
        }
        /// <summary>
        /// Get a tournament entity containing a list of registered members.
        /// </summary>
        /// <param name="tournamentId"></param>
        /// <returns>Tournament entity joined with MemberTournament or null.</returns>
        public Tournament? GetWithMembers(Guid tournamentId)
        {
            return _context.Tournaments.Include(t => t.Members).FirstOrDefault(t => t.Id == tournamentId);
        }

        public ICollection<Member> GetRegisteredPlayers(Guid tournamentId)
        {
            Tournament t = GetWithMembers(tournamentId) ?? throw new Exception("Tournament not found");
            return t.Members ?? new List<Member>();
        }

        public void InsertMatchups(Tournament t, IEnumerable<Matchup> matchups)
        {
            foreach (var item in matchups)
            {
                _context.Matchups.Add(item);
            }

            _context.SaveChanges();
        }

        public Tournament? GetWithMatchups(Guid tournamentId)
        {
            return _context.Tournaments.Include(t => t.Matchups).FirstOrDefault(t => t.Id == tournamentId);
        }

        public Tournament? GetWithPlayedRound(Guid tournamentId, int RoundNumber)
        {
            //return _context.Tournaments.AsNoTracking()
            //    .Include(t => t.Matchups.Where(m => m.Round <= RoundNumber).Select(m => m.White))
            //    .Include(t => t.Members)
            //    .FirstOrDefault(t => t.Id.Equals(tournamentId));

            return _context.Tournaments.Include(t => t.Members)
                .Include(t => t.Matchups).ThenInclude(m => m.White)
                .Include(t => t.Matchups).ThenInclude(m => m.Black)
                .FirstOrDefault(t => t.Id.Equals(tournamentId));

        }
    }
}
