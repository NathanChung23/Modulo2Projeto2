using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace M2_Lista2
{
    static class Criptografia
    {
        public static string Criptografar(string senha)
        {
            var encodedValue = Encoding.UTF8.GetBytes(senha);
            var encryptedPassword = SHA1.Create().ComputeHash(encodedValue);

            var sb = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
