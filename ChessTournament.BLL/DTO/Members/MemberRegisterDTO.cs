using ChessTournament.BLL.Tools.CustomValidationAttribute;
using ChessTournament.DL.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.DTO.Members
{
    public class MemberRegisterDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage ="Username lenght must be between {1} and {2}.")]
        public string Pseudo { get; set; } = string.Empty;
        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Password lenght must be between {1} and {2}.")]
        public string Password { get; set; } = string.Empty;
        [Required]
        [Range(0, 3000, ErrorMessage ="Value for {0} must be between {1} and {2}.")]
        public double? Elo { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        [BeforeToday]
        public DateTime Birthday { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
