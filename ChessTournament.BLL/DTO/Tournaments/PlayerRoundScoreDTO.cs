using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.DTO.Tournaments
{
    public class PlayerRoundScoreDTO
    {
        public string Username { get; set; } = string.Empty;
        public int MatchCount { get; set; } = 0;
        public int VictoryCount { get; set; } = 0;
        public int LossCount { get; set; } = 0;
        public int DrawCount { get; set; } = 0;
        public double Score { get; set; } = 0;
    }
}
