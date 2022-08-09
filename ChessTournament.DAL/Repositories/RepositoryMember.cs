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
    public class RepositoryMember : RepositoryBase<Guid, Member>, IMemberRepository
    {
        public RepositoryMember(ChessTournamentContext context) : base(context)
        {

        }
    }
}
