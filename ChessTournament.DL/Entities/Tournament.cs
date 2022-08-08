using ChessTournament.DL.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.DL.Entities
{
    public class Tournament
    {
        public Guid Id { get; set; }
        public int MinPlayer { get; set; }
        public int MaxPlayer { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public int? EloMin { get; set; }
        public int? EloMax { get; set; }
        public Categorie TournamentCategorie { get; set; }
        public TournamentStatus TournamentStatus { get; set; }
        public int CurrentRound { get; set; }
        public bool IsWomen { get; set; }
        public DateTime TournamentCreationDate { get; set; }
        public DateTime TournamentEndDate { get; set; }
        public DateTime TournamentModifyDate { get; set; }


    }
}
