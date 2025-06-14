using Domain.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        // Esto de acá no crea todas estas tablas sino que las hace disponibles para consultas en vez de tener que llamar a la tabla Users
        public DbSet<Client> clients { get; set; }
        public DbSet<SysAdmin> sysAdmins { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // User (abstract base)
            modelBuilder.Entity<User>()
             .HasDiscriminator<RolesEnum>("Role")
             .HasValue<Client>(RolesEnum.Client)
             .HasValue<SysAdmin>(RolesEnum.SysAdmin);

            // Client - Reservation
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Client)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Court)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CourtId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<SysAdmin>().HasData(new SysAdmin
            {
                Id = 1,
                FullName = "El Predio",
                Email = "elpredio@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("000"),
                PhoneNumber = "3412121111",
                Role = RolesEnum.SysAdmin
            }
            );

            modelBuilder.Entity<Client>().HasData(new Client
            {
                Id = 2,
                FullName = "Joaquin Tanlongo",
                Email = "joako.tanlon@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("123"),
                PhoneNumber = "3412122907",
                Role = RolesEnum.Client
            },
            new Client
            {
                Id = 3,
                FullName = "Maximo Martin",
                Email = "marmax0504@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("456"),
                PhoneNumber = "3412122908",
                Role = RolesEnum.Client
            },
            new Client
            {
                Id = 4,
                FullName = "Mario Massonnat",
                Email = "marucomass@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("789"),
                PhoneNumber = "3412122909",
                Role = RolesEnum.Client
            },
            new Client
            {
                Id = 5,
                FullName = "Francisco Depetrini",
                Email = "frandepe7@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("111"),
                PhoneNumber = "3412122910",
                Role = RolesEnum.Client
            }
        );
             



        modelBuilder.Entity<Court>().HasData(new Court
            {
                Id = 1,
                Name = "5A",
                Duration = "60 min",
                Price = 40000,
                Description = "Cancha techada con cesped cintetico y caucho",
                Category = "Techada"
            },
            new Court
            {
                Id = 2,
                Name = "5B",
                Duration = "60 min",
                Price = 45000,
                Description = "Cancha techada con cesped cintetico y caucho",
                Category = "Techada"
            },
            new Court
            {
                Id = 3,
                Name = "6A",
                Duration = "60 min",
                Price = 60000,
                Description = "Cancha techada con cesped cintetico y caucho",
                Category = "Techada"
            },
            new Court
            {
                Id = 4,
                Name = "6C",
                Duration = "60 min",
                Price = 60000,
                Description = "Cancha techada con cesped cintetico y caucho",
                Category = "Techada"
            },
            new Court
            {
                Id = 5,
                Name = "7T",
                Duration = "60 min",
                Price = 70000,
                Description = "Cancha techada con cesped cintetico y caucho",
                Category = "Techada"
            },
            new Court
            {
                Id = 6,
                Name = "7AL",
                Duration = "60 min",
                Price = 70000,
                Description = "Cancha al aire libre con cesped cintetico y caucho",
                Category = "Aire Libre"
            },
            new Court
            {
                Id = 7,
                Name = "8AL",
                Duration = "60 min",
                Price = 83000,
                Description = "Cancha al aire libre con cesped cintetico y caucho",
                Category = "Aire Libre"
            }
            );

        }
    }
}
