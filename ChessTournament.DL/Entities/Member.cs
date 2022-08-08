using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.DL.Entities
{
    public class Member
    {
        public Guid Id { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime Birthday { get; set; }

    }
}
