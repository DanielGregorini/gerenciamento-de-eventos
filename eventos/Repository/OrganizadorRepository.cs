using System;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using Eventos.Classes;
using Eventos.Data;

namespace Eventos.Repository
{
    class OrganizadorRepository
    {
        static public void AdicionarOrganizador(Organizador organizador)
        {
            using (var context = new EventContext())
            {
                context.Organizadores.Add(organizador);
                context.SaveChanges();
            }
        }

        static public void ExcluirOrganizador(Organizador organizador)
        {
            using (var context = new EventContext())
            {
                context.Organizadores.Remove(organizador);
                context.SaveChanges();
            }
        }

        static public void EditarOrganizador(int id, string novoNome, string novoEmail)
        {
            using (var context = new EventContext())
            {
                var organizadorParaEditar = context.Organizadores.Find(id);

                if (organizadorParaEditar == null)
                {
                    Console.WriteLine("Organizador não encontrado!!");
                    return;
                }

                organizadorParaEditar.Nome = novoNome;
                organizadorParaEditar.Email = novoEmail;

                context.SaveChanges();
                Console.WriteLine("Organizador editado!!");
            }
        }

        static public List<Organizador> ListarOrganizadores()
        {
            using (var context = new EventContext())
            {
                var organizadores = context.Organizadores.ToList();
                return organizadores;
            }
        }

        static public Organizador OrganizadorPorId(int id)
        {
            using (var context = new EventContext())
            {
                var organizador = context.Organizadores.Find(id);

                if (organizador == null)
                {
                    throw new ArgumentException("ID de organizador não encontrado");
                }

                return organizador;
            }
        }
    }
}
