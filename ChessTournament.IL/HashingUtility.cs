using Isopoh.Cryptography.Argon2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.IL
{
    public class HashingUtility
    {
        public static string PasswordHash(string password)
        {
            return Argon2.Hash(password);
            Argon2.Hash
        }
    }
}
