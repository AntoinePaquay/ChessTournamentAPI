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
            Tournament t = tournamentAddDTO.FromBLLToDL();   
            t.Status = TournamentStatus.PendingPlayers;
            t.CurrentRound = 0;
            t.Created = DateTime.Now;
            t.Update = DateTime.Now;
            DateTime DeadLine = t.Created.AddDays(t.MinPlayer);
            if (t.RegisterationDeadLine < t.Created.AddDays(t.MinPlayer))
            {
                throw new Exception($"La date de fin des inscriptions doit être supérieur au {t.Created.AddDays(t.MinPlayer)}");
            }
            return _repository.Create(t);
        }

        public bool Delete(Guid id)
        {
            Tournament t = new Tournament();
            if(t.Status == TournamentStatus.Ongoing)
            {
                throw new Exception("Vous ne pouvez pas supprimer un tournoi en cours");
            }
            return _repository.Delete(id);
        }
    }
}
