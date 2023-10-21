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
using Microsoft.Extensions.Logging;
using System.Data;

namespace Eventos.UI
{
    class EventoUI
    {
        public static void EventoTela()
        {

            int menuEscolha = 0;

            while (menuEscolha != 6)
            {
                Console.Clear();
                Console.WriteLine("--- Tela de Eventos ---");
                Console.WriteLine();
                Console.WriteLine("1 - Listar eventos;");
                Console.WriteLine("2 - Buscar por ID;");
                Console.WriteLine("3 - Adicionar Evento;");
                Console.WriteLine("4 - Atualizar por ID;");
                Console.WriteLine("5 - Deletar por ID;");
                Console.WriteLine("6 - Retornar ao Menu Principal.");
                Console.WriteLine();
                Console.Write("Selecione uma opção: ");
                menuEscolha = Retorna.LerInteiro();

                switch (menuEscolha)
                {


                    case 1:
                        ListarLocais();
                        break;

                    case 2:
                        BuscarLocalPorID();
                        break;

                    case 3:
                        AdicionarLocal();
                        break;

                    case 4:
                        AtualizarLocalPorID();
                        break;

                    case 5:
                        DeletarLocalPorID();

                        break;

                    case 6:

                        break;


                }
            }
        }

        private static void ListarEventos()
        {
            var eventos = EventoRepository.ListarEventos();

            Console.WriteLine(" Todos os eventos:\n");

            foreach (var evento in eventos)
            {
                Console.WriteLine($"ID: {evento.IdEvento}, Nome: {evento.Nome}, Endereço: Capacidade: {evento.Data} " +
                    $"ID do local:{evento.LocalID}, nome do local do evento {evento.Local.Nome}");
            }

            Console.ReadKey();

        }

        private static void BuscarEventoPorID()
        {
            int id;

            Console.WriteLine("ID do evento:");
            id = Retorna.LerInteiro();

            var evento = EventoRepository.EventoPorId(id);

            Console.WriteLine($"ID: {evento.IdEvento}, Nome: {evento.Nome}, Endereço: Capacidade: {evento.Data} " +
                    $"ID do local:{evento.LocalID}, nome do local do evento {evento.Local.Nome}");

            Console.ReadKey();
        }

        //public int IdEvento { get; set; }
        //public string Nome { get; set; }
        //public DateTime Data { get; set; }
        //public int LocalID { get; set; }
        //public Local? Local { get; set; }
        //public int OrganizadorID { get; set; }
        //public Organizador Organizador { get; set; }
        //public List<ParticipanteEvento> ParticipantesInscritos { get; set; }

        private static void AdicionarEvento()
        {
            string nome;
            DateTime data;

            Console.WriteLine("Nome do evento");
            nome = Retorna.LerString();

            Console.WriteLine("Data do evento");
            data = Retorna.LerDateTime();

            var evento = new Evento
            {
                Nome = nome,
                Data = data,
                
            };

            EventoRepository.AdicionarEvento(evento);
            Console.ReadKey();
        }

        private static void AtualizarLocalPorID()
        {
            string nome, endereco;
            int capacidade;
            int id;
            bool loop = true;
            var local = new Local();


            while (loop)
            {
                Console.WriteLine("Id do local, 0 se quiser voltar:");
                id = Retorna.LerInteiro();

                if (id == 0)
                {
                    return;
                }

                local = LocalRepository.LocalPorId(id);

                if (local != null)
                {
                    loop = false; // Defina loop como false para sair do loop quando o local for encontrado
                }
                else
                {
                    Console.WriteLine("Local não encontrado. Tente novamente.");
                    return;
                }
            }

            id = local.IdLocal;

            Console.WriteLine("Novo Nome do local");
            nome = Retorna.LerString();

            Console.WriteLine("Novo Endereço do local");
            endereco = Retorna.LerString();

            Console.WriteLine("Nova Capacidade do local");
            capacidade = Retorna.LerInteiro();

            LocalRepository.EditarLocal(id, nome, endereco, capacidade);
            Console.WriteLine($"ID: {id} {nome} foi atualizado");
            Console.ReadKey();

        }

        private static void DeletarLocalPorID()
        {
            int id;
            bool loop = true;
            var local = new Local();

            while (loop)
            {
                Console.WriteLine("Id do local, 0 se quiser voltar:");
                id = Retorna.LerInteiro();

                if (id == 0)
                {
                    return;
                }

                local = LocalRepository.LocalPorId(id);

                if (local != null)
                {
                    loop = false; // Defina loop como false para sair do loop quando o local for encontrado
                }
                else
                {
                    Console.WriteLine("Local não encontrado. Tente novamente.");
                    return;
                }

            }

            LocalRepository.ExcluirLocal(local);
            Console.WriteLine($"ID: {local.IdLocal} {local.Capacidade} FOI DELETADO COM SUCESSO!!!");
            Console.ReadKey();

        }

    }
}
