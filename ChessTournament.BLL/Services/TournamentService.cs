using ChessTournament.BLL.DTO.SignUps;
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
        private ITournamentRepository _tournamentRepository;
        private IMemberRepository _memberRepository;

        public TournamentService(ITournamentRepository repository, IMemberRepository memberRepository)
        {
            _tournamentRepository = repository;
            _memberRepository = memberRepository;
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
            if(t.Status == TournamentStatus.Ongoing)
            {
                throw new Exception("You can't delete an on going tournament");
            }
            return _tournamentRepository.Delete(id);
        }

        public IEnumerable<TournamentDTO> LastTenTournamentUpdated()
        {
            return _tournamentRepository
                .LastTenTournamentUpdated()
                .Select(t=>new TournamentDTO(t));
        }
    }
}
