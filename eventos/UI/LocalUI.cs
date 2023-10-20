using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Eventos.Classes;
using Eventos.Repository;
using Eventos.Data;
using Eventos.Utilities;

namespace Eventos.UI
{
    class LocalUI
    {
        public static void LocalTela()
        {
            bool menu = true;
            int menuEscolha;



            while (menu)
            {

                Console.WriteLine("\nMenu\n");
                Console.WriteLine("1-Tela Eventos");
                Console.WriteLine("2-Tela Local");
                Console.WriteLine("3-Tela Organizador");
                Console.WriteLine("4-Tela Participante");
                menuEscolha = Retorna.LerInteiro();

                switch (menuEscolha)
                {


                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:

                        break;


                }
            }
        }


    }
}
