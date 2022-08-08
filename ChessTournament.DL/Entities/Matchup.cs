using ChessTournament.DL.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.DL.Entities
{
    public class Matchup
    {
        public Guid Id { get; set; }
        public Member White { get; set; } = null!;
        public Member Black { get; set; } = null!;
        public Tournament Tournament { get; set; } = null!;
        public int Round { get; set; }
        public Result Result { get; set; }
    }
}
