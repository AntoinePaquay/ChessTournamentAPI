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
            if (t.RegisterationDeadLine < t.Created.AddDays(t.MinPlayer))

            {
                throw new Exception($"La date de fin des inscriptions doit être supérieur au {t.Created.AddDays(t.MinPlayer)}");
            }
            return _tournamentRepository.Create(t);
        }

        public bool Delete(Guid id)
        {
            Tournament t = new Tournament();
            if(t.Status == TournamentStatus.Ongoing)
            {
                throw new Exception("Vous ne pouvez pas supprimer un tournoi en cours");
            }
            return _tournamentRepository.Delete(id);
        }

        public void SignUp(TournamentSignUpDTO dto)
        {
            Tournament t = _tournamentRepository.GetById(dto.TournamentId) ?? throw new ArgumentNullException("Tournament not found.");
            Member m = _memberRepository.GetById(dto.PlayerId) ?? throw new ArgumentNullException("Player not found.");

            if (t.Status != TournamentStatus.PendingPlayers) throw new Exception("Tournament has already started.");
            if (t.RegisterationDeadLine > DateTime.Now) throw new Exception("Sign up has closed.");
            if (_tournamentRepository.IsPlayerSignedUp(dto.TournamentId, dto.PlayerId)) throw new Exception("Player has already signedup.");
            if (_tournamentRepository.GetSignUpCount(dto.TournamentId) >= t.MaxPlayer) throw new Exception("Tournament is already full");

            TimeSpan ageTS = t.RegisterationDeadLine - m.Birthday;
            double age = ageTS.TotalDays / 365.2425;

            if (t.Category == Category.Junior && age > 18) throw Exception("Player is not allowed in this category")
        }
    }
}
