using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace practicaInterview.Services
{
    public class EncryptionService
    {
        public static string ComputeSHA256(string texto)
        {
            string hash = String.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));

                foreach (byte b in hashValue)
                {
                    hash += $"{b:X2}";
                }
            }

            return hash;
        }
    }
}
