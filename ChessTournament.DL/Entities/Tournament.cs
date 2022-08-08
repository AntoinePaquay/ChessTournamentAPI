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
        public int minPlayer { get; set; }
        public int maxPlayer { get; set; }

        public int? eloMin { get; set; }
        public int? eloMax { get; set; }
        public Categorie TournamentCategorie { get; set; }
        public ProjectStatus tournamentStatus { get; set; }
        public int currentRound { get; set; }
        public bool isWomen { get; set; }
        public DateTime tournamentCreationDate { get; set; }
        public DateTime tournamentEndDate { get; set; }
        public DateTime tournamentModifyDate { get; set; }


    }
}
