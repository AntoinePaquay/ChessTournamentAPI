using ChessTournament.BLL.Tools.CustomValidationAttribute;
using ChessTournament.DL.Entities;
using ChessTournament.DL.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.DTO.Tournaments
{
    public class TournamentAddDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(2, 32)]
        public int MinPlayer { get; set; }
        [Required]
        [Range(2, 32)]
        [GreaterOrEqualThanAttribute(nameof(MinPlayer))]
        public int MaxPlayer { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }

        [Range(0, 3000)]
        public int? EloMin { get; set; }
        [Range(0, 3000)]
        [GreaterOrEqualThanAttribute(nameof(EloMin))]
        public int? EloMax { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public bool IsWomenOnly { get; set; }
        public DateTime RegisterationDeadLine { get; set; }


    }
}
