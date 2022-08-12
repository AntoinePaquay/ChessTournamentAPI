using ChessTournament.BLL.DTO.SignUps;
using ChessTournament.BLL.Interfaces;
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
    public class SignUpService : ISignUpService
    {
        private ITournamentRepository _TournamentRepository;
        private IMemberRepository _MemberRepository;

        public SignUpService(IMemberRepository memberRepository, ITournamentRepository tournamentRepository)
        {
            _MemberRepository = memberRepository;
            _TournamentRepository = tournamentRepository;
        }
        public void SignUp(SignUpDTO dto)
        {
            Tournament t = _TournamentRepository.GetById(dto.TournamentId) ?? throw new ArgumentNullException("Tournament not found.");
            Member m = _MemberRepository.GetById(dto.PlayerId) ?? throw new ArgumentNullException("Player not found.");

            if (t.Status != TournamentStatus.PendingPlayers) throw new Exception("Tournament has already started.");
            if (t.RegisterationDeadLine < DateTime.Now) throw new Exception("Sign up has closed.");
            if (_TournamentRepository.IsPlayerSignedUp(dto.TournamentId, dto.PlayerId)) throw new Exception("Player has already signedup.");
            if (_TournamentRepository.GetSignUpCount(dto.TournamentId) >= t.MaxPlayer) throw new Exception("Tournament is already full");

            TimeSpan ageTS = t.RegisterationDeadLine - m.Birthday;
            double age = ageTS.TotalDays / 365.2425;

            if (!t.Category.HasFlag(Category.Junior) && age < 18) throw new Exception("Juniors are not allowed in this tournament");
            if (!t.Category.HasFlag(Category.Senior) && age > 18 && age < 60) throw new Exception("Seniors are not allowed in this tournament");
            if (!t.Category.HasFlag(Category.Veteran) && age > 60) throw new Exception("Veterans are not allowed in this tournament"); 

            if (m.Elo < t.EloMin || m.Elo > t.EloMax) throw new Exception($"Player elo({m.Elo}) is not between {t.EloMin} and {t.EloMax}.");
            if (t.IsWomenOnly && m.Gender == Gender.Man) throw new Exception($"Gender '{m.Gender}' is not allowed in Woman only tournament.");

            _TournamentRepository.SignUserUp(t.Id, m.Id);
        }

        public void Withdraw(WithdrawDTO dto, Guid MemberId)
        {
            Tournament t = _TournamentRepository.GetById(dto.TournamentId) ?? throw new ArgumentException("No tournament matches the provided Id");
            if (!_TournamentRepository.IsPlayerSignedUp(dto.TournamentId, MemberId)) throw new ArgumentException("Player is not signed up");
            if (t.Status != TournamentStatus.PendingPlayers) throw new Exception("The tournament is no longer accepting sign ups");

            _TournamentRepository.WithdrawUser(dto.TournamentId, MemberId);
        }
    }
}
