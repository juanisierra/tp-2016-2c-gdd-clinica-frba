using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ClinicaFrba.Utils
{
    class Hash
    {
        public static byte[] ComputePasswordHash(string password)
        {
            byte[] passwordBytes = UTF8Encoding.UTF8.GetBytes(password);
            byte[] preHashed = new byte[passwordBytes.Length];
            System.Buffer.BlockCopy(passwordBytes, 0, preHashed, 0, passwordBytes.Length);
            SHA256 sha256 = SHA256.Create();
            return sha256.ComputeHash(preHashed);
        }
    }
}
