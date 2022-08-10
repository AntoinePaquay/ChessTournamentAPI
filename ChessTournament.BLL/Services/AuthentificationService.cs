using ChessTournament.BLL.DTO.Members;
using ChessTournament.BLL.Interfaces;
using ChessTournament.BLL.Mappers;
using ChessTournament.DAL.Interfaces;
using ChessTournament.DL.Entities;
using ChessTournament.DL.Enumerations;
using ChessTournament.IL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        private IMemberRepository _Repository;

        public AuthentificationService(IMemberRepository repository)
        {
            _Repository = repository;
        }
        public bool Register(MemberRegisterDTO dto)
        {
            if (_Repository.Exists(m => m.Email == dto.Email))
            {
                return false;
            }

            if (_Repository.Exists(m => m.Pseudo == dto.Pseudo))
            {
                return false;
            }

            Member m = dto.ToEntity();
            m.Salt = Guid.NewGuid();
            m.PasswordHash = HashingUtility.Hash(dto.Password, m.Salt);
            m.Elo = dto.Elo ?? 1200;
            m.Role = Role.User;
            
            return _Repository.Create(m);
        }
    }
}
