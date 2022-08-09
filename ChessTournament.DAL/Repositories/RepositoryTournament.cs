using ChessTournament.DAL.Context;
using ChessTournament.DAL.Interfaces;
using ChessTournament.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.DAL.Repositories
{
    public class RepositoryTournament : RepositoryBase<Guid, Tournament>, ITournamentRepository
    {
        public RepositoryTournament(ChessTournamentContext context) : base(context)
        {

        }
    }
}
