﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Eventos.Classes;
using Eventos.Data;
using Microsoft.Extensions.Logging;

namespace Eventos.Data
{
    class EventContext : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Organizador> Organizadores { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<ParticipanteEvento> ParticipanteEventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //ver os log do efcore
                //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

                string connectionString = "Server=localhost;Database=db_evento;User=root;Password=admin;";

                optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 25)));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ParticipanteEvento>()
                .HasKey(pe => new { pe.IdParticipante, pe.IdEvento });

            modelBuilder.Entity<ParticipanteEvento>()
                .HasOne(pe => pe.Participante)
                .WithMany(p => p.EventosInscritos)
                .HasForeignKey(pe => pe.IdParticipante);

            modelBuilder.Entity<ParticipanteEvento>()
                .HasOne(pe => pe.Evento)
                .WithMany(e => e.ParticipantesInscritos)
                .HasForeignKey(pe => pe.IdEvento);
        }
    }
}