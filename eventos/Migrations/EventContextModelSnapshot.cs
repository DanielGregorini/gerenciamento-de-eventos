﻿// <auto-generated />
using System;
using Eventos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TPTE_09.Migrations
{
    [DbContext(typeof(EventContext))]
    partial class EventContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Eventos.Classes.Evento", b =>
                {
                    b.Property<int>("IdEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("LocalID")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("OrganizadorID")
                        .HasColumnType("int");

                    b.HasKey("IdEvento");

                    b.HasIndex("LocalID");

                    b.HasIndex("OrganizadorID");

                    b.ToTable("tb_evento");
                });

            modelBuilder.Entity("Eventos.Classes.Local", b =>
                {
                    b.Property<int>("IdLocal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdLocal");

                    b.ToTable("tb_local");
                });

            modelBuilder.Entity("Eventos.Classes.Organizador", b =>
                {
                    b.Property<int>("IdOrganizador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdOrganizador");

                    b.ToTable("tb_organizador");
                });

            modelBuilder.Entity("Eventos.Classes.Participante", b =>
                {
                    b.Property<int>("IdParticipante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdParticipante");

                    b.ToTable("tb_participante");
                });

            modelBuilder.Entity("Eventos.Classes.ParticipanteEvento", b =>
                {
                    b.Property<int>("IdParticipanteEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdEvento")
                        .HasColumnType("int");

                    b.Property<int>("IdParticipante")
                        .HasColumnType("int");

                    b.HasKey("IdParticipanteEvento");

                    b.HasIndex("IdEvento");

                    b.HasIndex("IdParticipante");

                    b.ToTable("tb_participante_evento");
                });

            modelBuilder.Entity("Eventos.Classes.Evento", b =>
                {
                    b.HasOne("Eventos.Classes.Local", "Local")
                        .WithMany("Eventos")
                        .HasForeignKey("LocalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eventos.Classes.Organizador", "Organizador")
                        .WithMany("EventosOrganizados")
                        .HasForeignKey("OrganizadorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Local");

                    b.Navigation("Organizador");
                });

            modelBuilder.Entity("Eventos.Classes.ParticipanteEvento", b =>
                {
                    b.HasOne("Eventos.Classes.Evento", "Evento")
                        .WithMany("ParticipantesInscritos")
                        .HasForeignKey("IdEvento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eventos.Classes.Participante", "Participante")
                        .WithMany("EventosInscritos")
                        .HasForeignKey("IdParticipante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Participante");
                });

            modelBuilder.Entity("Eventos.Classes.Evento", b =>
                {
                    b.Navigation("ParticipantesInscritos");
                });

            modelBuilder.Entity("Eventos.Classes.Local", b =>
                {
                    b.Navigation("Eventos");
                });

            modelBuilder.Entity("Eventos.Classes.Organizador", b =>
                {
                    b.Navigation("EventosOrganizados");
                });

            modelBuilder.Entity("Eventos.Classes.Participante", b =>
                {
                    b.Navigation("EventosInscritos");
                });
#pragma warning restore 612, 618
        }
    }
}
