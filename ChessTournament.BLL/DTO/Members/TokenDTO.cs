using ChessTournament.DL.Entities;
using ChessTournament.DL.Enumerations;

namespace ChessTournament.BLL.DTO
{
    public class TokenDTO
    {
        public string Pseudo { get; set; } = string.Empty;
        public Guid Id { get; set; }
        public Role Role { get; set; }

        public TokenDTO(Member m)
        {
            Pseudo = m.Pseudo;
            Id = m.Id;
            Role = m.Role;
        }
        public TokenDTO()
        {

        }
    }
}
