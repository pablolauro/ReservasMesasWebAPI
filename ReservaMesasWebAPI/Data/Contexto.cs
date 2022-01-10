using Microsoft.EntityFrameworkCore;
using ReservaMesasWebAPI.Models;

namespace ReservaMesasWebAPI.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<AreaMesa> AreaMesas { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder opt)
        {
            opt.UseSqlServer(@"Data Source = localhost; initial Catalog = ReservaMesasAPI; User ID = usuario; password = senha; language = Portuguese; Trusted_Connection = True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mesa>()
                .HasOne(m => m.area)
                .WithMany(a => a.mesas)
                .HasForeignKey(m => m.idAreaMesa);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.mesa)
                .WithMany(m => m.reservas)
                .HasForeignKey(r => r.mesaId);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.cliente)
                .WithMany(c => c.reservas)
                .HasForeignKey(r => r.clienteId);

        }


    }
}   
