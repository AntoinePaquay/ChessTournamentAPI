using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.DTO.SignUps
{
    public class SignUpDTO
    {
        public Guid TournamentId { get; set; }
        public Guid PlayerId { get; set; }
    }
}
