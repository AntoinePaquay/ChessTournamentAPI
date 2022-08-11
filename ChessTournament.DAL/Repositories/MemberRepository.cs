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
        public Member GetMemberByPseudo(string pseudo)
        {
            Member? m;
            try
            {
                m = _context.Set<Member>().FirstOrDefault(m => m.Pseudo == pseudo);
                return m ?? throw new Exception();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Member GetMemberByEmail(string email)
        {
            Member? m;
            try
            {
                m = _context.Set<Member>().FirstOrDefault(m => m.Email == email);
                return m ?? throw new Exception();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
