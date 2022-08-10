using ChessTournament.BLL.DTO.Members;
using ChessTournament.DAL.Interfaces;
using ChessTournament.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.Interfaces
{
    public interface IAuthentificationService
    {
        public bool Register(MemberRegisterDTO dto)
    }
}
