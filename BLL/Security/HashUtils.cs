using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Security
{
   internal class HashUtils
    {
        /// <summary>
        /// Aplicará o algoritmo de HASH MD5, utilizando
        /// um "salt".
        /// </summary>
        /// <param name="password">Senha bruta</param>
        /// <returns>Senha "hasheada"</returns>
        public static string HashPassword(string password)
        {
            //Adicionar um valor de Salt
            string saltValue = "@#aleatorystringsltvalue#2912934";
            //SHA1.Create().ComputeHash()

            //Adiciona o salt na senha e transforma para uma 
            //representação númerica em vetor
            byte[] UTF8Codification =
                Encoding.UTF8.GetBytes(saltValue + password + saltValue);

            //Invoca o método 
            byte[] hashedPassword =
                SHA1.Create().ComputeHash(UTF8Codification);

            //Retorna a senha hasheada utilizando codificação
            //utilizada por aplicações WEB.
            return Convert.ToBase64String(hashedPassword);
        }
    }
}
