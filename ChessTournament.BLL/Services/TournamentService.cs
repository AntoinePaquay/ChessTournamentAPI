using ChessTournament.BLL.DTO.Tournaments;
using ChessTournament.BLL.Interfaces;
using ChessTournament.BLL.Tools.Mappers;
using ChessTournament.DAL.Interfaces;
using ChessTournament.DL.Entities;
using ChessTournament.DL.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.Services
{
    public class TournamentService : ITournamentService
    {
        private ITournamentRepository _repository;

        public TournamentService(ITournamentRepository repository)
        {
            _repository = repository;
        }

        public bool Create(TournamentAddDTO tournamentAddDTO)
        {
            Tournament tournament = tournamentAddDTO.FromBLLToDL();
            tournament.Status = TournamentStatus.PendingPlayers;
            tournament.CurrentRound = 0;
            tournament.Created = DateTime.Now;
            tournament.Modified = DateTime.Now;
            DateTime DeadLine = tournament.Created.AddDays(tournament.MinPlayer);
            if (tournament.RegisterationDeadLine < tournament.Created.AddDays(tournament.MinPlayer))
            {
                throw new Exception($"La date de fin des inscriptions doit être supérieur au {tournament.Created.AddDays(tournament.MinPlayer)}");
            }
            return _repository.Create(tournamentAddDTO.FromBLLToDL());
        }

        public bool Delete(Guid id)
        {
            return _repository.Delete(id);
        }
    }
}
