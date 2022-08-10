using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.DTO.Authentification
{
    public class MemberLoginDTO
    {
        public string Identifier { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

}
