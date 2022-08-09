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
        [Range(2,32)]
        public int MinPlayer { get; set; }
        [Range(2,32)]
        public int MaxPlayer { get; set; }
        public Address? Address { get; set; }
        [Range(0,3000)]
        public int? EloMin { get; set; }
        [Range(0, 3000)]
        public int? EloMax { get; set; }
        [Required]
        public Categorie categorie { get; set; }
        [Required]
        public bool IsWomenOnly { get; set; }


}
}
