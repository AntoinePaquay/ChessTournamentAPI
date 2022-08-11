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
                EloMin = tournament.EloMin,
                EloMax = tournament.EloMax,
                Category = tournament.Category,
                IsWomenOnly = tournament.IsWomenOnly,
                RegisterationDeadLine = tournament.RegisterationDeadLine
            };
        }

        public static Tournament FromBLLToDL(this TournamentAddDTO tournament)
        {
            Address a = new Address();
            a.Id = Guid.NewGuid();
            a.Country = tournament.Country;
            a.PostalCode = tournament.PostalCode;
            a.Street = tournament.Street;
            a.HouseNumber = tournament.HouseNumber;
            a.City = tournament.City;
            a.Province = tournament.Province;

            return new Tournament
            {
                Name = tournament.Name,
                MinPlayer = tournament.MinPlayer,
                MaxPlayer = tournament.MaxPlayer,
                EloMin = tournament.EloMin,
                EloMax = tournament.EloMax,
                Category = tournament.Category,
                IsWomenOnly = tournament.IsWomenOnly,
                RegisterationDeadLine = tournament.RegisterationDeadLine,
                Address = a
            };
        }
    }
}
