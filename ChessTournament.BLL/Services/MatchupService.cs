using ChessTournament.BLL.DTO.Matchups;
using ChessTournament.BLL.Interfaces;
using ChessTournament.DAL.Interfaces;
using ChessTournament.DAL.Repositories;
using ChessTournament.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.Services
{
    public class MatchupService : IMatchupService
    {
        private IMatchupRepository _MatchupRepository;
        public MatchupService(IMatchupRepository matchupRepository)
        {
            _MatchupRepository = matchupRepository;
        }

        public void SetResult(SetResultDTO dto)
        {
            Matchup m = _MatchupRepository.GetWithTournament(dto.MatchupId) ?? throw new ArgumentException("Matchup not found.");
            if (m.Result == dto.Result) return;
            if (m.Tournament.CurrentRound != m.Round) throw new Exception("Matchup doesn't belong to the current round.");
            m.Result = dto.Result;
            _MatchupRepository.SaveChanges();
        }
    }
}
