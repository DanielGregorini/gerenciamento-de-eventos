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
                        ListarEventos();
                        break;

                    case 2:
                        BuscarEventoPorID();
                        break;

                    case 3:
                        AdicionarEvento();
                        break;

                    case 4:
                        AtualizarEventoPorID();
                        break;

                    case 5:
                        DeletarEventoPorID();

                        break;

                    case 6:

                        break;


                }
            }
        }

        private static void ListarEventos()
        {
            var eventos = EventoRepository.ListarEventos();
            var local = new Local();

            if(eventos.Count == 0) {
                Console.WriteLine("Não tem nem um evento cadastrado");
                Console.ReadKey();
                return;
            }

            Console.WriteLine(" Todos os eventos:\n");

            foreach (var evento in eventos)
            {
                local = LocalRepository.LocalPorId(evento.LocalID);

                Console.WriteLine($"ID: {evento.IdEvento}, Nome: {evento.Nome}, Data: {evento.Data}, " +
                    $"ID Local: {local.IdLocal}, Nome do local: {local.Nome}, Capacidade do local: {local.Capacidade}");
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

        private static void AdicionarEvento()
        {
            string nome;
            int idOrganizador, idLocal;
            DateTime data;

            Console.WriteLine("Nome do evento");
            nome = Retorna.LerString();

            Console.WriteLine("Data do evento");
            data = Retorna.LerDateTime();

            Console.WriteLine("ID do Local do evento");
            idLocal = Retorna.LerInteiro();
            var local = LocalRepository.LocalPorId(idLocal);

            Console.WriteLine("ID do Organizador do evento");
            idOrganizador = Retorna.LerInteiro();
            var organizador = OrganizadorRepository.OrganizadorPorId(idOrganizador);

            var evento = new Evento
            {
                Nome = nome,
                Data = data,
                LocalID = local.IdLocal,
                OrganizadorID = organizador.IdOrganizador,
            };

            EventoRepository.AdicionarEvento(evento);
            Console.ReadKey();
        }

        private static void AtualizarEventoPorID()
        {
            string Novonome;
            int id, idNovoOrganizador, idNovoLocal;
            DateTime novaData;

            bool loop = true;
            var evento = new Evento();
           
            while (loop)
            {
                Console.WriteLine("Id do local, 0 se quiser voltar:");
                id = Retorna.LerInteiro();

                if (id == 0)
                {
                    return;
                }

                evento = EventoRepository.EventoPorId(id);

                if (evento != null)
                {
                    loop = false; // Defina loop como false para sair do loop quando o local for encontrado
                }
                else
                {
                    Console.WriteLine("Evento não encontrado. Tente novamente.");
                    return;
                }
            }

            id = evento.IdEvento;

            Console.WriteLine("Novo nome do evento");
            Novonome = Retorna.LerString();

            Console.WriteLine("Nova data do evento");
            novaData = Retorna.LerDateTime();

            Console.WriteLine("ID do novo Organizador");
            idNovoOrganizador = Retorna.LerInteiro();
           
            Console.WriteLine("ID do novo Local");
            idNovoLocal = Retorna.LerInteiro();

            EventoRepository.EditarEvento(id, Novonome, novaData, idNovoLocal, idNovoOrganizador);
            Console.WriteLine($"ID: {id} {Novonome} foi atualizado");
            Console.ReadKey();
        }

        private static void DeletarEventoPorID()
        {
            int id;
            bool loop = true;
            var evento = new Evento();

            while (loop)
            {
                Console.WriteLine("Id do Evento, 0 se quiser voltar:");
                id = Retorna.LerInteiro();

                if (id == 0)
                {
                    return;
                }

                evento = EventoRepository.EventoPorId(id);

                if (evento != null)
                {
                    loop = false; // Defina loop como false para sair do loop quando o evento for encontrado
                }
                else
                {
                    Console.WriteLine("Evento não encontrado. Tente novamente.");
                    return;
                }

            }

            EventoRepository.ExcluirEvento(evento);
            Console.WriteLine($"ID: {evento.IdEvento} {evento.Nome} FOI DELETADO COM SUCESSO!!!");
            Console.ReadKey();
        }
    }
}
