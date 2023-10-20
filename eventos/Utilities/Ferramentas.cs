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

                if (!sucesso)
                {
                    Console.WriteLine("Por favor, escreva um número valido");
                }

            } while (!sucesso);

            return numero;
        }
    }
}
