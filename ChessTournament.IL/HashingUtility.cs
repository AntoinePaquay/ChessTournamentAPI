using Isopoh.Cryptography.Argon2;
using Isopoh.Cryptography.SecureArray;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.IL
{
    public class HashingUtility
    {
        public static string Hash(string password, Guid salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = salt.ToByteArray();
            byte[] secret = Encoding.UTF8.GetBytes("M1cky pr3s1d3nt !");

            var config = new Argon2Config
            {
                Type = Argon2Type.DataIndependentAddressing,
                Version = Argon2Version.Nineteen,
                TimeCost = 10,
                MemoryCost = 32768,
                Lanes = 5,
                Threads = Environment.ProcessorCount,
                Password = passwordBytes,
                Salt = saltBytes,
                Secret = secret,
                HashLength = saltBytes.Length,
            };

            var argon2A = new Argon2(config);
            using (SecureArray<byte> hashA = argon2A.Hash())
            {
                return config.EncodeString(hashA.Buffer);
            }
        }
    }
}