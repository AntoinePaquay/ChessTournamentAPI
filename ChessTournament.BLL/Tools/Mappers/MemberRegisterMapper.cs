using ChessTournament.BLL.DTO.Members;
using ChessTournament.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.Mappers
{
    public static class MemberRegisterMapper
    {
        public static Member ToEntity(this MemberRegisterDTO dto)
        {
            return new Member
            {
                Pseudo = dto.Pseudo,
                Email = dto.Email,
                Gender = dto.Gender,
                Birthday = dto.Birthday
            };
        }
    }
}
