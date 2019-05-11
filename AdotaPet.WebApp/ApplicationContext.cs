using System;
using System.Collections.Generic;
using AdotaPet.WebApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdotaPet.WebApp
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Adocao> Adocao { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Doenca> Doenca { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Raca> Raca { get; set; }
        public DbSet<Ong> Ong { get; set; }
        public DbSet<Adocao_Itens> Adocao_Itens { get; set; }
        public DbSet<Financeiro> Financeiro { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if Debug
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-5P677KP4;Initial Catalog=Db_AdotaPet;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
#endif
#if Debug_G
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-5P677KP4;Initial Catalog=Db_AdotaPet;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
#endif
#if Debug_E
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-I4PCENV;Initial Catalog=Db_AdotaPet;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
#endif
        }
    }
}