using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.DTO.Tournaments
{
    public class TournamentSignUpDTO
    {
        [Required]
        public Guid TournamentId { get; set; }
        [Required]
        public Guid PlayerId { get; set; }
    }
}
