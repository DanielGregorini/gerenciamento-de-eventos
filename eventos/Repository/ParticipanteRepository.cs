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
    class ParticipanteRepository
    {
        static public void AdicionarParticipante(Participante participante)
        {

            using (var context = new EventContext())
            {
                context.Participantes.Add(participante);
                context.SaveChanges();
            }
        }

        static public void ExcluirParticipante(Participante participante)
        {

            using (var context = new EventContext())
            {
                context.Participantes.Remove(participante);
                context.SaveChanges();
            }
        }

        static public void EditarParticipante(int id, string novoNome, string novoEmail)
        {
            using (var context = new EventContext())
            {
                var produtoParaEditar = context.Participantes.Find(id);

                if (produtoParaEditar != null)
                {
                    Console.WriteLine("Participante não encontrado!!");
                    return;
                }

                produtoParaEditar.Nome = novoNome;
                produtoParaEditar.Email = novoEmail;

                context.SaveChanges();
                Console.WriteLine("Participante editado!!");
            }
        }

        static public List<Participante> ListarParticipantes()
        {
            using (var context = new EventContext())
            {
                var participantes = context.Participantes.ToList();
                return participantes;
            }
        }

        static public Participante ParticipantePorId(int id)
        {
            using (var context = new EventContext())
            {
                var participante = context.Participantes.Find(id);

                if (participante == null)
                {
                    throw new ArgumentException("ID não achado");
                }

                return participante;
            }
        }
    }
}
