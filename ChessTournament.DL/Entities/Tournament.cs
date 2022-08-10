using ChessTournament.DL.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.DL.Entities
{
    public class Tournament: IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int MinPlayer { get; set; }
        public int MaxPlayer { get; set; }
        public Address Address { get; set; } = null!;
        public int? EloMin { get; set; }
        public int? EloMax { get; set; }
        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
        public Category Category { get; set; }
        public TournamentStatus Status { get; set; }
        public int CurrentRound { get; set; }
        public bool IsWomenOnly { get; set; }
        public DateTime Created { get; set; }
        public DateTime RegisterationDeadLine { get; set; }
        public DateTime Update { get; set; }
        public virtual ICollection<Matchup> Matchups { get; set; } = new List<Matchup>();

    }
}
