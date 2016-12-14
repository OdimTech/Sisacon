using System.Text;

namespace Helpers
{
    public static class Security
    {
        /// <summary>
        /// Criptografa a string informada
        /// </summary>
        /// <param name="decryptedValue"></param>
        /// <returns>String criptografada</returns>
        public static string encrypt(string decryptedValue)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(decryptedValue);

            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
