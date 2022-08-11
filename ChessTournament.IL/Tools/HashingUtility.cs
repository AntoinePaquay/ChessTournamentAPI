using Isopoh.Cryptography.Argon2;
using Isopoh.Cryptography.SecureArray;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.IL.Tools
{
    public class HashingUtility
    {
        private readonly static byte[] _Secret = Encoding.UTF8.GetBytes("M1cky pr3s1d3nt !");
        public static string Hash(string password, Guid salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = salt.ToByteArray();


            var config = new Argon2Config
            {
                Type = Argon2Type.DataIndependentAddressing,
                Version = Argon2Version.Nineteen,
                Password = passwordBytes,
                Salt = saltBytes,
                Secret = _Secret,
            };

            var argon2A = new Argon2(config);
            using (SecureArray<byte> hashA = argon2A.Hash())
            {
                return config.EncodeString(hashA.Buffer);
            }
        }

        public static bool Verify(string password, string passwordHash, Guid salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            var configOfPasswordToVerify = new Argon2Config
            {
                Password = passwordBytes,
                Secret = _Secret
                ,
                Salt = salt.ToByteArray(),
                Type = Argon2Type.DataIndependentAddressing,
                Version = Argon2Version.Nineteen
            };
            SecureArray<byte> hashB = null;

            try
            {
                if (configOfPasswordToVerify.DecodeString(passwordHash, out hashB) && hashB != null)
                {
                    var argon2ToVerify = new Argon2(configOfPasswordToVerify);
                    using (var hashToVerify = argon2ToVerify.Hash())
                    {
                        if (Argon2.FixedTimeEquals(hashB, hashToVerify))
                        {
                            return true;
                        }
                    }
                }
            }
            finally
            {
                hashB?.Dispose();
            }
            return false;
        }


    }
}