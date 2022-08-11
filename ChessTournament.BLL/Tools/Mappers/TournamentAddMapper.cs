using ChessTournament.BLL.DTO.Tournaments;
using ChessTournament.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.Tools.Mappers
{
    public static class TournamentAddMapper
    {
        public static TournamentAddDTO FromDLToBLL(this Tournament tournament)
        {
            return new TournamentAddDTO
            {
                Name = tournament.Name,
                MinPlayer = tournament.MinPlayer,
                MaxPlayer = tournament.MaxPlayer,
                Address = tournament.Address,
                EloMin = tournament.EloMin,
                EloMax = tournament.EloMax,
                Category = tournament.Category,
                IsWomenOnly = tournament.IsWomenOnly,
                RegisterationDeadLine = tournament.RegisterationDeadLine
            };
        }

        public static Tournament FromBLLToDL(this TournamentAddDTO tournament)
        {
            return new Tournament
            {
                Name = tournament.Name,
                MinPlayer = tournament.MinPlayer,
                MaxPlayer = tournament.MaxPlayer,
                Address = tournament.Address,
                EloMin = tournament.EloMin,
                EloMax = tournament.EloMax,
                Category = tournament.Category,
                IsWomenOnly = tournament.IsWomenOnly,
                RegisterationDeadLine = tournament.RegisterationDeadLine
            };
        }
    }
}
