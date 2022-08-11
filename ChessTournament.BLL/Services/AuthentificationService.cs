using ChessTournament.BLL.DTO;
using ChessTournament.BLL.DTO.Authentification;
using ChessTournament.BLL.DTO.Members;
using ChessTournament.BLL.Interfaces;
using ChessTournament.BLL.Mappers;
using ChessTournament.DAL.Interfaces;
using ChessTournament.DL.Entities;
using ChessTournament.DL.Enumerations;
using ChessTournament.IL.Exceptions;
using ChessTournament.IL.Tools;

namespace ChessTournament.BLL.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        private IMemberRepository _Repository;

        public AuthentificationService(IMemberRepository repository)
        {
            _Repository = repository;
        }
        public void Register(MemberRegisterDTO dto)
        {
            if (_Repository.Exists(m => m.Email == dto.Email))
            {
                throw new UniqueValueAlreadyUsedException(message: "Email is already in use.");
            }

            if (_Repository.Exists(m => m.Pseudo == dto.Pseudo))
            {
                throw new UniqueValueAlreadyUsedException(message: "Username is already in use.");
            }

            Member m = dto.ToEntity();
            m.Salt = Guid.NewGuid();
            m.PasswordHash = HashingUtility.Hash(dto.Password, m.Salt);
            m.Elo = dto.Elo ?? 1200;
            m.Role = Role.User;
            m.Id = Guid.NewGuid();

            _Repository.Create(m);
        }

        public TokenDTO Login(MemberLoginDTO dto)
        {
            if (dto.Pseudo is null && dto.Email is null) throw new Exception("Username or email must be provided.");
            if (dto.Pseudo is not null && dto.Email is not null) throw new Exception("Provide only one identifier.");
            if (dto.Pseudo is not null && !_Repository.Exists(m => m.Pseudo == dto.Pseudo)) throw new Exception("Provided username is not found.");
            if (dto.Email is not null && !_Repository.Exists(m => m.Email == dto.Email)) throw new Exception("Provided username is not found.");

            Member m = new();

            if (dto.Pseudo is not null)
            {
                m = _Repository.GetMemberByPseudo(dto.Pseudo);
            }
            if (dto.Email is not null)
            {
                m = _Repository.GetMemberByEmail(dto.Email);
            }

            if (HashingUtility.Verify(dto.Password, m.PasswordHash, m.Salt))
            {
                return new TokenDTO(m);
            }
            else
            {
                throw new Exception("Wrong password");
            }
            

        }
    }
}
