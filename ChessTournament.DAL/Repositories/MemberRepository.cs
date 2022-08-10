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
    public class MemberRepository : RepositoryBase<Guid, Member>, IMemberRepository
    {
        public MemberRepository(ChessTournamentContext context) : base(context)
        {

        }
    }
}
