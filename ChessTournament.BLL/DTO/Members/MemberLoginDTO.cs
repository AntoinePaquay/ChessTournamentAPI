using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.DTO.Authentification
{
    public class MemberLoginDTO
    {
        public string? Pseudo { get; set; } = null!;
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string Password { get; set; } = null!;
    }

}
