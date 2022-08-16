using ChessTournament.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.DAL.Interfaces
{
    public interface ITournamentRepository : IRepository<Guid, Tournament>
    {
        bool IsPlayerSignedUp(Guid tournamentId, Guid MemberId);
        int GetSignUpCount(Guid tournamentId);
        public IEnumerable<Tournament> LastTenTournamentUpdated();
        void SignUserUp(Guid tournamentId, Guid memberId);
        void WithdrawUser(Guid tournamentId, Guid memberId);
        ICollection<Member> GetRegisteredPlayers(Guid tournamentId);
        Tournament? GetWithMembers(Guid tournamentId);
        void InsertMatchups(Tournament t, IEnumerable<Matchup> matchups);
        Tournament? GetWithMatchups(Guid tournamentId);
        Tournament? GetWithPlayedRound(Guid tournamentId, int RoundNumber);
    }
}
