using Eventos.Classes;
using Eventos.Repository;
using Eventos.Data;
using Eventos.Utilities;


namespace Eventos.UI
{
    class OrganizadorUI
    {
        public static void OrganizadorTela()
        {

            int menuEscolha = 0;

            while (menuEscolha != 6)
            {
                Console.Clear();
                Console.WriteLine("--- Tela de Organizador ---");
                Console.WriteLine();
                Console.WriteLine("1 - Listar Organizadores;");
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
                        ListarOrganizadores();
                        break;

                    case 2:
                        BuscarOrganizadorPorID();
                        break;

                    case 3:
                        AdicionarOrganizador();
                        break;

                    case 4:
                        AtualizarOrganizadorPorID();
                        break;

                    case 5:
                        DeletarOrganizadorPorID();

                        break;

                    case 6:

                        break;


                }
            }
        }

        private static void ListarOrganizadores()
        {
            var organizadores = OrganizadorRepository.ListarOrganizadores();

            if (organizadores.Count == 0)
            {
                Console.WriteLine("Não tem nem um organizadores cadastrado");
                Console.ReadKey();
                return;
            }

            Console.WriteLine(" Todos os locais:\n");

            foreach (var organizador in organizadores)
            {
                Console.WriteLine($"ID: {organizador.IdOrganizador}, Nome: {organizador.Nome}," +
                    $" Endereço: Capacidade: {organizador.Email}");
            }

            Console.ReadKey();

        }

        private static void BuscarOrganizadorPorID()
        {
            int id;

            Console.WriteLine("ID do Organizador:");
            id = Retorna.LerInteiro();

            var organizador = OrganizadorRepository.OrganizadorPorId(id);

            Console.WriteLine($"ID: {organizador.IdOrganizador}, Nome: {organizador.Nome}, " +
                $"Email: {organizador.Email}");

            Console.ReadKey();
        }

        private static void AdicionarOrganizador()
        {
            string nome, email;

            Console.WriteLine("Nome do Organizador");
            nome = Retorna.LerString();

            Console.WriteLine("Email do Organizador");
            email = Retorna.LerString();


            var organizdor = new Organizador
            {
                Nome = nome,
                Email = email
            };

            OrganizadorRepository.AdicionarOrganizador(organizdor);
            Console.ReadKey();
        }

        private static void AtualizarOrganizadorPorID()
        {
            string nome, email;
            int id;
            bool loop = true;
            var organizador = new Organizador();


            while (loop)
            {
                Console.WriteLine("Id do local, 0 se quiser voltar:");
                id = Retorna.LerInteiro();

                if (id == 0)
                {
                    return;
                }

                organizador = OrganizadorRepository.OrganizadorPorId(id);

                if (organizador != null)
                {
                    loop = false; // Defina loop como false para sair do loop quando o local for encontrado
                }
                else
                {
                    Console.WriteLine("Organizador não encontrado. Tente novamente.");
                    return;
                }
            }

            id = organizador.IdOrganizador;

            Console.WriteLine("Novo Nome do Organizador");
            nome = Retorna.LerString();

            Console.WriteLine("Novo email do Organizador");
            email = Retorna.LerString();

            OrganizadorRepository.EditarOrganizador(id, nome, email);
            Console.WriteLine($"ID: {id} {nome} foi atualizado");
            Console.ReadKey();

        }

        private static void DeletarOrganizadorPorID()
        {
            int id;
            bool loop = true;
            var organizador = new Organizador();

            while (loop)
            {
                Console.WriteLine("Id do Organizador, 0 se quiser voltar:");
                id = Retorna.LerInteiro();

                if (id == 0)
                {
                    return;
                }

                organizador = OrganizadorRepository.OrganizadorPorId(id);

                if (organizador != null)
                {
                    loop = false; 
                }
                else
                {
                    Console.WriteLine("Organizador não encontrado. Tente novamente.");
                    return;
                }

            }

            OrganizadorRepository.ExcluirOrganizador(organizador);
            Console.WriteLine($"ID: {organizador.IdOrganizador} {organizador.Nome} FOI DELETADO COM SUCESSO!!!");
            Console.ReadKey();
        }
    }
}
