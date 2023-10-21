using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Eventos.Classes;
using Eventos.Repository;
using Eventos.Data;
using Eventos.UI;
using Eventos.Utilities;

namespace Eventos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            // Criar um organizador
            Organizador organizador = new Organizador
            {
                Nome = "João Silva",
                Email = "joao@example.com"
            };

            Console.WriteLine(organizador);

            OrganizadorRepository.AdicionarOrganizador(organizador);


            // Criar um local
            Local local = new Local
            {
                Nome = "Centro de Convenções",
                Endereco = "Rua Principal, 123",
                Capacidade = 10
            };

            LocalRepository.AdicionarLocal(local);

            // Criar um evento associado ao organizador e local
            Evento evento = new Evento
            {
                Nome = "Conferência de Tecnologia",
                Data = DateTime.Now.AddDays(30), // Data da conferência daqui a 30 dias
                OrganizadorID = organizador.IdOrganizador,
                LocalID = local.IdLocal
            };

            EventoRepository.AdicionarEvento(evento);

            // Criar e inserir 10 participantes no evento
            for (int i = 1; i <= 11; i++)
            {
                Participante participante = new Participante
                {
                    Nome = $"Participante pedro {i}",
                    Email = $"participante{i}@example.com"
                };

                ParticipanteRepository.AdicionarParticipante(participante);

                // Associar o participante ao evento
                ParticipanteEvento participanteEvento = new ParticipanteEvento
                {
                    IdParticipante = participante.IdParticipante,
                    IdEvento = evento.IdEvento
                };

                ParticipanteEventoRepository.AdicionarParticipanteEvento(participanteEvento);
            }
            */
            Console.Clear();
            Console.WriteLine("\nSistema gerenciador de eventos\n");
            Console.WriteLine("\nBy: Daniel Mahl Gregorini\n");
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