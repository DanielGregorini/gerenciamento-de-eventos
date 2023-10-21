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

            int menuEscolha = 0;

            while (menuEscolha != 6)
            {
                Console.Clear();
                Console.WriteLine("--- Tela de Locais ---");
                Console.WriteLine();
                Console.WriteLine("1 - Listar locais;");
                Console.WriteLine("2 - Buscar por ID;");
                Console.WriteLine("3 - Adicionar Local;");
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

        private static void ListarLocais()
        {
            var locais = LocalRepository.ListarLocais();

            Console.WriteLine(" Todos os locais:\n");

            foreach (var local in locais)
            {
                Console.WriteLine($"ID: {local.IdLocal}, Nome: {local.Nome}, Endereço: Capacidade: {local.Capacidade} " +
                    $"Endereço: {local.Endereco}");
            }

            Console.ReadKey();

        }

        private static void BuscarLocalPorID()
        {
            int id;

            Console.WriteLine("ID do local:");
            id = Retorna.LerInteiro();

            var local = LocalRepository.LocalPorId(id);

            Console.WriteLine($"ID: {local.IdLocal}, Nome: {local.Nome}, Capacidade: {local.Capacidade} " +
                    $"Endereço: {local.Endereco}");

            Console.ReadKey();
        }

        private static void AdicionarLocal()
        {
            string nome, endereco;
            int capacidade;

            Console.WriteLine("Nome do local");
            nome = Retorna.LerString();

            Console.WriteLine("Endereço do local");
            endereco = Retorna.LerString();

            Console.WriteLine("Capacidade do local");
            capacidade = Retorna.LerInteiro();


            var local = new Local
            {
                Nome = nome,
                Endereco = endereco,
                Capacidade = capacidade
            };

            LocalRepository.AdicionarLocal(local);
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