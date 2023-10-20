using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using Eventos.Classes;
using Eventos.Data;

namespace Eventos.Repository
{
    class EventoRepository
    {

        static public void AdicionarEvento(Evento evento)
        {
            using (var context = new EventContext())
            {
                context.Eventos.Add(evento);
                context.SaveChanges();
            }
        }

        static public void ExcluirEvento(Evento evento)
        {
            using (var context = new EventContext())
            {
                context.Eventos.Remove(evento);
                context.SaveChanges();
            }
        }

        static public void EditarEvento(int id, string novoNome, DateTime novaData, int novoLocalId, int novoOrganizadorId)
        {
            using (var context = new EventContext())
            {
                var eventoParaEditar = context.Eventos.Find(id);

                if (eventoParaEditar == null)
                {
                    Console.WriteLine("Evento não encontrado!!");
                    return;
                }

                eventoParaEditar.Nome = novoNome;
                eventoParaEditar.Data = novaData;
                eventoParaEditar.LocalID = novoLocalId;
                eventoParaEditar.OrganizadorID = novoOrganizadorId;

                context.SaveChanges();
                Console.WriteLine("Evento editado!!");
            }
        }

        static public List<Evento> ListarEventos()
        {
            using (var context = new EventContext())
            {
                var eventos = context.Eventos.ToList();
                return eventos;
            }
        }

        static public Evento EventoPorId(int id)
        {
            using (var context = new EventContext())
            {
                var evento = context.Eventos.Find(id);

                if (evento == null)
                {
                    throw new ArgumentException("ID de evento não encontrado");
                }

                return evento;
            }
        }
    }
}
