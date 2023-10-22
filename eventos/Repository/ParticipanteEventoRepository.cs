using System;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using Eventos.Classes;
using Eventos.Data;

namespace Eventos.Repository
{
    class ParticipanteEventoRepository
    {

        static public void AdicionarParticipanteEvento(ParticipanteEvento participanteEvento)
        {
            using (var context = new EventContext())
            {
                //o evento do que o participante vai ir
                var evento = context.Eventos.Find(participanteEvento.IdEvento);

                if (evento == null)
                {
                    Console.WriteLine("Evento não encontrado!");
                    return;
                }

                //local do evento
                var local = context.Locais.Find(evento.LocalID);

                if (local == null)
                {
                    Console.WriteLine("Evento não encontrado!");
                    return;
                }

                //quantidade maxima de pessoas que podem ir no local do evento
                int capacidadeMaxima = local.Capacidade;

                //conta quantas participantes estao associados no evento
                int numeroParticipantes = context.ParticipanteEventos.Count(pe => pe.IdEvento == participanteEvento.IdEvento);

                if (numeroParticipantes >= capacidadeMaxima)
                {
                    Console.WriteLine("Capacidade máxima do evento atingida. Não é possível adicionar mais participantes.");
                }
                else
                {
                    context.ParticipanteEventos.Add(participanteEvento);
                    context.SaveChanges();
                    Console.WriteLine("Participante adicionado ao evento com sucesso.");
                }

            }
        }

        static public void RemoverParticipanteEvento(ParticipanteEvento participanteEvento)
        {

            using (var context = new EventContext())
            {
               
                context.ParticipanteEventos.Remove(participanteEvento);
                context.SaveChanges();
                
            }
        }

        static public List<ParticipanteEvento> ListarTodosParticipanteEventos()
        {
            using (var context = new EventContext())
            {     
                return context.ParticipanteEventos.ToList();
            }
           
        }

        static public ParticipanteEvento EncontrarParticipanteEventoPorId(int idEvento, int idParticipante)
        {
            using (var context = new EventContext())
            {
                var participante = new Participante();
                var evento = context.Eventos.Find(idEvento);

                foreach(var participante_ in evento.ParticipantesInscritos)
                {
                    if (participante_.IdParticipante == idParticipante)
                    {
                        participante = context.Participantes.Find(participante_.IdParticipante);
                        var eventoparticipante = new ParticipanteEvento
                        {
                            IdParticipante = participante_.IdParticipante,
                            IdEvento = participante_.IdParticipante
                        };

                        return eventoparticipante;
                    }
                }
                return null;
            } 
        }
    }
}
