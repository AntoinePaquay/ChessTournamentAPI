using ChessTournament.DL.Entities;
using ChessTournament.DL.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.DTO.Tournaments
{
    public class TournamentDTO
    {
        public TournamentDTO(Tournament tournament)
        {
            Id = tournament.Id;
            Name = tournament.Name;
            Address = tournament.Address;
            PlayerCount = tournament.Members.Count;
            MinPlayer = tournament.MinPlayer;
            MaxPlayer = tournament.MaxPlayer;
            EloMin = tournament.EloMin;
            EloMax = tournament.EloMax;
            Category = tournament.Category;
            Status = tournament.Status;
            CurrentRound = tournament.CurrentRound;
            RegisterationDeadLine = tournament.RegisterationDeadLine;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; } = null!;
        public int PlayerCount { get; set; }
        public int MinPlayer { get; set; }
        public int MaxPlayer { get; set; }
        public int? EloMin { get; set; }
        public int? EloMax { get; set; }
        public Category Category { get; set; }
        public TournamentStatus Status { get; set; }
        public int CurrentRound { get; set; }
        public DateTime RegisterationDeadLine { get; set; }
    }
}
