using ChessTournament.BLL.DTO.SignUps;
using ChessTournament.BLL.DTO.Tournaments;
using ChessTournament.DAL.Interfaces;
using ChessTournament.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.Interfaces
{
    public interface ITournamentService 
    {
        public IEnumerable<TournamentDTO> LastTenTournamentUpdated();
        bool Create(TournamentAddDTO tournamentAddDTO);
        bool Delete(Guid id);
        void StartTournament(TournamentIdDTO dto);
        void AdvanceRound(TournamentIdDTO dto);
         IEnumerable<PlayerRoundScoreDTO> GetRoundScores(Guid id, int round);
    }
}
