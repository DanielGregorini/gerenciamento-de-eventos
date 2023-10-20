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
    class LocalRepository
    {

        static public void AdicionarLocal(Local local)
        {
            using (var context = new EventContext())
            {
                context.Locais.Add(local);
                context.SaveChanges();
            }
        }

        static public void ExcluirLocal(Local local)
        {
            using (var context = new EventContext())
            {
                context.Locais.Remove(local);
                context.SaveChanges();
            }
        }

        static public void EditarLocal(int id, string novoNome, string novoEndereco, int novaCapacidade)
        {
            using (var context = new EventContext())
            {
                var localParaEditar = context.Locais.Find(id);

                if (localParaEditar == null)
                {
                    Console.WriteLine("Local não encontrado!!");
                    return;
                }

                localParaEditar.Nome = novoNome;
                localParaEditar.Endereco = novoEndereco;
                localParaEditar.Capacidade = novaCapacidade;

                context.SaveChanges();
                Console.WriteLine("Local editado!!");
            }
        }

        static public List<Local> ListarLocais()
        {
            using (var context = new EventContext())
            {
                var locais = context.Locais.ToList();
                return locais;
            }
        }

        static public Local LocalPorId(int id)
        {
            using (var context = new EventContext())
            {
                var local = context.Locais.Find(id);

                if (local == null)
                {
                    throw new ArgumentException("ID de local não encontrado");
                }

                return local;
            }
        }
    }
}
