using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Eventos.Classes;
using Eventos.UI;
using Eventos.Repository;
using Eventos.Data;
using Eventos.Utilities;


namespace Eventos
{
    internal class Program
    {
        static void Main(string[] args)
        {





















            Console.Clear();
            Console.WriteLine("----- Sistema gerenciador de eventos -----\n\n");
            Console.WriteLine("By: Daniel Mahl Gregorini\n");
            Console.ReadKey();

            int menuEscolha = 0;

            while (menuEscolha != 5)
            {
                Console.WriteLine("\nMenu\n");
                Console.WriteLine("1-Tela Eventos");
                Console.WriteLine("2-Tela Local");
                Console.WriteLine("3-Tela Organizador");
                Console.WriteLine("4-Tela Participante");
                Console.WriteLine("5-Fechar");
                menuEscolha = Retorna.LerInteiro();

                switch(menuEscolha)
                {


                    case 1:
                        EventoUI.EventoTela();
                        break;

                    case 2:
                        LocalUI.LocalTela();
                        break;

                    case 3:
                        OrganizadorUI.OrganizadorTela();
                        break;

                    case 4:
                        ParticipanteUI.ParticipanteTela();
                        break;

                    case 5:

                        break;

                }
            }
        }
    }
}