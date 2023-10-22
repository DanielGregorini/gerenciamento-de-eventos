using Eventos.Classes;
using Eventos.Repository;
using Eventos.Data;
using Eventos.Utilities;

namespace Eventos.UI
{
    class ParticipanteUI
    {

        public static void ParticipanteTela()
        {

            int menuEscolha = 0;

            while (menuEscolha != 7)
            {
                Console.Clear();
                Console.WriteLine("--- Tela de Participantes ---");
                Console.WriteLine();
                Console.WriteLine("1 - Listar Participantes;");
                Console.WriteLine("2 - Buscar por ID;");
                Console.WriteLine("3 - Adicionar Participante;");
                Console.WriteLine("4 - Atualizar por ID;");
                Console.WriteLine("5 - Deletar por ID;");
                Console.WriteLine("6 - Insirir participante em evento;");
                Console.WriteLine("7 - Retornar ao Menu Principal.");
                Console.WriteLine();
                Console.Write("Selecione uma opção: ");
                menuEscolha = Retorna.LerInteiro();

                switch (menuEscolha)
                {

                    case 1:
                        ListarParticipantes();
                        break;

                    case 2:
                        BuscarParticipantePorID();
                        break;

                    case 3:
                        AdicionarParticipante();
                        break;

                    case 4:
                        AtualizarParticipantePorID();
                        break;

                    case 5:
                        DeletarParticipantePorID();

                        break;

                    case 6:
                        AdicionarParticipanteEmEvento();
                        break;

                }
            }
        }

        private static void ListarParticipantes()
        {
            var participantes = ParticipanteRepository.ListarParticipantes();

            if (participantes.Count == 0)
            {
                Console.WriteLine("Não tem nem um participantes cadastrado");
                Console.ReadKey();
                return;
            }

            Console.WriteLine(" Todos os participantes:\n");

            foreach (var participante in participantes)
            {
                Console.WriteLine($"ID: {participante.IdParticipante}, Nome: {participante.Nome}," +
                    $" Endereço: Capacidade: {participante.Email}");
            }

            Console.ReadKey();

        }

        private static void BuscarParticipantePorID()
        {
            int id;

            Console.WriteLine("ID do Participante:");
            id = Retorna.LerInteiro();

            var participante = ParticipanteRepository.ParticipantePorId(id);

            Console.WriteLine($"ID: {participante.IdParticipante}, Nome: {participante.Nome}, " +
                $"Email: {participante.Email}");

            Console.ReadKey();
        }

        private static void AdicionarParticipante()
        {
            string nome, email;

            Console.WriteLine("Nome do novo Participante");
            nome = Retorna.LerString();

            Console.WriteLine("Email do novo Participante");
            email = Retorna.LerString();


            var participante = new Participante
            {
                Nome = nome,
                Email = email
            };

            ParticipanteRepository.AdicionarParticipante(participante);
            Console.ReadKey();
        }

        private static void AtualizarParticipantePorID()
        {
            string nome, email;
            int id;
            bool loop = true;
            var participante = new Participante();


            while (loop)
            {
                Console.WriteLine("Id do participante, 0 se quiser voltar:");
                id = Retorna.LerInteiro();

                if (id == 0)
                {
                    return;
                }

                participante = ParticipanteRepository.ParticipantePorId(id);

                if (participante != null)
                {
                    loop = false; // Defina loop como false para sair do loop quando o local for encontrado
                }
                else
                {
                    Console.WriteLine("Participante não encontrado. Tente novamente.");
                    return;
                }
            }

            id = participante.IdParticipante;

            Console.WriteLine("Novo Nome do Participante");
            nome = Retorna.LerString();

            Console.WriteLine("Novo email do Participante");
            email = Retorna.LerString();

            ParticipanteRepository.EditarParticipante(id, nome, email);
            Console.WriteLine($"ID: {id} {nome} foi atualizado");
            Console.ReadKey();

        }

        private static void DeletarParticipantePorID()
        {
            int id;
            bool loop = true;
            var participante = new Participante();

            while (loop)
            {
                Console.WriteLine("Id do Participante, 0 se quiser voltar:");
                id = Retorna.LerInteiro();

                if (id == 0)
                {
                    return;
                }

                participante = ParticipanteRepository.ParticipantePorId(id);

                if (participante != null)
                {
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Participante não encontrado. Tente novamente.");
                    return;
                }

            }

            ParticipanteRepository.ExcluirParticipante(participante);
            Console.WriteLine($"ID: {participante.IdParticipante} {participante.Nome} FOI DELETADO COM SUCESSO!!!");
            Console.ReadKey();
        }

        private static void AdicionarParticipanteEmEvento()
        {
            int idParticipante;
            bool loop = true;
            var participante = new Participante();
            var evento = new Evento();

            while (loop)
            {
                Console.WriteLine("Id do participante, 0 se quiser voltar:");
                idParticipante = Retorna.LerInteiro();

                if (idParticipante == 0)
                {
                    return;
                }

                participante = ParticipanteRepository.ParticipantePorId(idParticipante);

                if (participante != null)
                {
                    loop = false; // Defina loop como false para sair do loop quando o local for encontrado
                }
                else
                {
                    Console.WriteLine("Participante não encontrado. Tente novamente.");
                    return;
                }
            }

            loop = true;

            while (loop)
            {
                Console.WriteLine($"Id do Evento que você o participante: {participante.IdParticipante} |" +
                    $" {participante.Nome}, 0 se quiser voltar:");
                idParticipante = Retorna.LerInteiro();

                if (idParticipante == 0)
                {
                    return;
                }

                evento = EventoRepository.EventoPorId(idParticipante);

                if (evento != null)
                {
                    loop = false; // Defina loop como false para sair do loop quando o local for encontrado
                }
                else
                {
                    Console.WriteLine("evento não encontrado. Tente novamente.");
                    return;
                }
            }

            ParticipanteEvento participanteEvento = new ParticipanteEvento
            {
            IdParticipante = participante.IdParticipante,
            IdEvento = evento.IdEvento
            };

            ParticipanteEventoRepository.AdicionarParticipanteEvento(participanteEvento);

            Console.WriteLine($"Participante {participante.IdParticipante}|{participante.Nome} associado " +
                $" ao evento {evento.IdEvento}|{evento.Nome}");
            Console.ReadKey();
        }

    }
}
