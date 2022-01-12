﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReservaMesasWebAPI.Data;

#nullable disable

namespace ReservaMesasWebAPI.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ReservaMesasWebAPI.Models.AreaMesa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("AreaMesas");
                });

            modelBuilder.Entity("ReservaMesasWebAPI.Models.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("usuarioId")
                        .IsUnique()
                        .HasFilter("[usuarioId] IS NOT NULL");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ReservaMesasWebAPI.Models.Mesa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<bool>("funcionando")
                        .HasColumnType("bit");

                    b.Property<int>("idAreaMesa")
                        .HasColumnType("int");

                    b.Property<int>("numMesa")
                        .HasColumnType("int");

                    b.Property<int>("qtdlugares")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idAreaMesa");

                    b.ToTable("Mesas");
                });

            modelBuilder.Entity("ReservaMesasWebAPI.Models.Reserva", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("clienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("horaFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("horainicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("mesaId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("clienteId");

                    b.HasIndex("mesaId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("ReservaMesasWebAPI.Models.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ReservaMesasWebAPI.Models.Cliente", b =>
                {
                    b.HasOne("ReservaMesasWebAPI.Models.Usuario", "usuario")
                        .WithOne("cliente")
                        .HasForeignKey("ReservaMesasWebAPI.Models.Cliente", "usuarioId");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("ReservaMesasWebAPI.Models.Mesa", b =>
                {
                    b.HasOne("ReservaMesasWebAPI.Models.AreaMesa", "area")
                        .WithMany("mesas")
                        .HasForeignKey("idAreaMesa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("area");
                });

            modelBuilder.Entity("ReservaMesasWebAPI.Models.Reserva", b =>
                {
                    b.HasOne("ReservaMesasWebAPI.Models.Cliente", "cliente")
                        .WithMany("reservas")
                        .HasForeignKey("clienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReservaMesasWebAPI.Models.Mesa", "mesa")
                        .WithMany("reservas")
                        .HasForeignKey("mesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");

                    b.Navigation("mesa");
                });

            modelBuilder.Entity("ReservaMesasWebAPI.Models.AreaMesa", b =>
                {
                    b.Navigation("mesas");
                });

            modelBuilder.Entity("ReservaMesasWebAPI.Models.Cliente", b =>
                {
                    b.Navigation("reservas");
                });

            modelBuilder.Entity("ReservaMesasWebAPI.Models.Mesa", b =>
                {
                    b.Navigation("reservas");
                });

            modelBuilder.Entity("ReservaMesasWebAPI.Models.Usuario", b =>
                {
                    b.Navigation("cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
