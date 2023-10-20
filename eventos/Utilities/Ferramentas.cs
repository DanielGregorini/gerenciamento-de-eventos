using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Utilities
{
    public class Retorna
    {
        public static int LerInteiro()
        {
            int numero;
            bool sucesso = false;

            do
            {
                string entrada = Console.ReadLine();

                sucesso = int.TryParse(entrada, out numero);

                if (!sucesso || numero < 0)
                {
                    Console.WriteLine("Por favor, escreva um número valido");
                    sucesso = true;
                }

            } while (!sucesso);

            return numero;
        }

        public static string LeiaString()
        {
            string entrada;

            do
            {
                entrada = Console.ReadLine();

                if (string.IsNullOrEmpty(entrada))
                {
                    Console.WriteLine("Você não pode retornar um valor nulo ou vazio. Tente novamente.");
                }
            } while (string.IsNullOrEmpty(entrada));

            return entrada;
        }
    }
}
