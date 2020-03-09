using Common.FlowControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Validators
{
   public static class PasswordValidator
    {
        public static Response ValidateSenha(string password, DateTime birthDate)
        {
            Response response = new Response();
            if (string.IsNullOrWhiteSpace(password))
            {
                response.Errors.Add("Senha deve ser informada");
            }
            if (password.Length < 8)
            {
                response.Errors.Add("Senha deve conter pelo menos 8 caracteres.") ;
            }

            if (password.Contains(birthDate.ToString("ddMM")))
            {
                response.Errors.Add("Senha não pode conter a data de nascimento");
            }

            //Verificar se a senha possui ao menos 3 letras (1 maiúscula, 1 minúscula)
            //3 numeros e 1 símbolo

            int qtdHighChar = 0;
            int qtdLowChar = 0;
            int qtdNumbers = 0;
            int qtdSimbols = 0;

            password = password.Replace(" ", "");

            foreach (char caractere in password)
            {
                if (char.IsLetter(caractere))
                {
                    if (char.IsUpper(caractere))
                    {
                        qtdHighChar++;
                    }
                    else
                    {
                        qtdLowChar++;
                    }
                }
                else if (char.IsNumber(caractere))
                {
                    qtdNumbers++;
                }
                else
                {
                    qtdSimbols++;
                }
            }

            int qtdLetters = qtdHighChar + qtdLowChar;

            if (qtdLetters < 3 || qtdLowChar < 1 || qtdHighChar < 1 || qtdNumbers < 3 || qtdSimbols < 1)
            {
                response.Errors.Add("A senha deve conter ao menos 3 letras (1 maiúscula e 1 minúscula), 3 números e 1 símbolo");
            }
            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                response.Success = true;
                return response;
            }
        }
    }
}
