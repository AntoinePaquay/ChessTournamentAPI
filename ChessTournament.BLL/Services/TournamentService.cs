using ChessTournament.BLL.DTO.SignUps;
using ChessTournament.BLL.DTO.Tournaments;
using ChessTournament.BLL.Interfaces;
using ChessTournament.BLL.Tools.Mappers;
using ChessTournament.DAL.Interfaces;
using ChessTournament.DL.Entities;
using ChessTournament.DL.Enumerations;
using ChessTournament.IL.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ChessTournament.BLL.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        public TournamentService(ITournamentRepository repository)
        {
            _tournamentRepository = repository;
        }
        public bool Create(TournamentAddDTO tournamentAddDTO)
        {
            Tournament t = tournamentAddDTO.FromBLLToDL();
            t.Status = TournamentStatus.PendingPlayers;
            t.CurrentRound = 0;
            t.Created = DateTime.Now;
            t.Update = DateTime.Now;
            DateTime DeadLine = t.Created.AddDays(t.MinPlayer);
            if (t.RegisterationDeadLine < DeadLine)

            {
                throw new Exception($"La date de fin des inscriptions doit être supérieur au {DeadLine}");
            }
            return _tournamentRepository.Create(t);
        }
        public bool Delete(Guid id)
        {
            Tournament t = new Tournament();
            if (t.Status == TournamentStatus.Ongoing)
            {
                throw new Exception("You can't delete an on going tournament");
            }
            return _tournamentRepository.Delete(id);
        }
        public IEnumerable<TournamentDTO> LastTenTournamentUpdated()
        {
            return _tournamentRepository
                .LastTenTournamentUpdated()
                .Select(t => new TournamentDTO(t));
        }
        public void StartTournament(TournamentIdDTO dto)
        {
            Tournament t = _tournamentRepository.GetWithMembers(dto.tournamentId) ?? throw new ArgumentException("Tournament not found.");
            if (t.Status != TournamentStatus.PendingPlayers) throw new Exception("Tournament is already started or finished.");
            if (t.MinPlayer > _tournamentRepository.GetSignUpCount(dto.tournamentId)) throw new Exception("Player count is insufficient.");
            //if (t.RegisterationDeadLine > DateTime.Now) throw new Exception("Registerations are still open.");
            List<Matchup> matchups = new();

            try
            {
                using (TransactionScope scope = new())
                {
                    matchups = (List<Matchup>)GenerateMatchUps(t);
                    t.Status = TournamentStatus.Ongoing;
                    t.Update = DateTime.Now;
                    t.CurrentRound = 1;
                    //t.Matchups = matchups;
                    _tournamentRepository.InsertMatchups(t, matchups);
                    scope.Complete();
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Generates the matchups for a given tournament. Each player plays against everyone 2 times, as black and white.
        /// </summary>
        /// <param name="t">The tournament entity that is being started</param>
        /// <returns>An ICollection of the generated Matchups</returns>
        private ICollection<Matchup> GenerateMatchUps(Tournament t)
        {
            List<Member> Members = (List<Member>)_tournamentRepository.GetRegisteredPlayers(t.Id);
            List<Matchup> matchups = new();
            //Required because DbContext is tracking the other list
            List<Member> players = Members.ToList();
            
            players.Shuffle();

            //Adding a new member to represent BYE if player count is odd. Default Guid will be "00000000-0000-0000-0000-000000000000".
            if (t.Members.Count % 2 == 1)
            {
                Member m = new();
                players.Add(m);
            }

            int playerCount = players.Count;
            Guid drawId = new();

            for (int round = 1; round < playerCount; round++)
            {
                for (int i = 0; i < playerCount / 2; i++)
                {
                    //Not creating a matchup if player has a BYE
                    if (players[i].Id != drawId && players[playerCount - i - 1].Id != drawId)
                    {
                        Matchup matchup = new()
                        {
                            Id = Guid.NewGuid(),
                            White = players[i],
                            Black = players[playerCount - i - 1],
                            Result = Result.PendingResult,
                            Round = round,
                            Tournament = t
                        };
                        matchups.Add(matchup);
                    }
                }

                players.Insert(1, players.Last());
                players.RemoveAt(players.Count - 1);
            }

            //Creating the return match
            matchups.AddRange(matchups.Select(m => new Matchup()
            {
                Id = Guid.NewGuid(),
                Black = m.White,
                White = m.Black,
                Round = m.Round + players.Count - 1,
                Tournament = t,
                Result = m.Result
            }).ToList());

            return matchups;
        }


    }
}
