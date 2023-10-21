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

            do
            {
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out numero) && numero >= 0)
                {
                    return numero;
                }

                Console.WriteLine("Por favor, digite um número inteiro não negativo.");
            } while (true);
        }

        public static string LerString()
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

        public static DateTime LerDateTime()
        {
            int ano = 0, mes = 0, dia = 0, horas = 0, minutos = 0;

            // Solicitar o ano
            Console.Write("Digite o ano: ");
            do
            {
                ano = LerInteiro();
            } while (ano < 1);

            // Solicitar o Mes
            Console.Write("Digite o mês: ");
            do
            {
                mes = LerInteiro();
            } while (mes < 1 || mes > 12);

            // Solicitar o dia
            Console.Write("Digite o dia: ");
            do
            {
                dia = LerInteiro();
            } while (dia < 1 || dia > DiasNoMes(mes, ano));


            // Solicitar as horas
            Console.Write("Digite as horas: ");
            do 
            {
                horas = LerInteiro();

            } while (horas < 0 || horas > 23) ;

            // Solicitar os minutos
            Console.Write("Digite os minutos: ");
            do
            {
                minutos = LerInteiro();
            } while (minutos < 0 || minutos > 59);

            // Criar o objeto DateTime com os valores fornecid 
            DateTime dataHora = new DateTime(ano, mes, dia, horas, minutos, 0);

            return dataHora;
        }

        public static int DiasNoMes(int mes, int ano)
        {
            switch (mes)
            {
                case 4:  // Abril
                case 6:  // Junho
                case 9:  // Setembro
                case 11: // Novembro
                    return 30;
                case 2: // Fevereiro
                    if ((ano % 4 == 0 && ano % 100 != 0) || ano % 400 == 0)
                    {
                        return 29; // Ano bissexto
                    }
                    else
                    {
                        return 28;
                    }
                default:
                    return 31;
            }
        }

    }
}
