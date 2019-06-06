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
        public DbSet<LarTemporario> LarTemporario { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if Debug
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-5P677KP4;Initial Catalog=Db_AdotaPet;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
#endif
#if Debug_G
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-I4PCENV;Initial Catalog=Db_AdotaPet;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
#endif
#if Debug_E
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Db_AdotaPet;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Adocao>().Ignore(a => a.Ong_Id);
            modelBuilder.Entity<Animal>().Ignore(a => a.Ong_Id);
            modelBuilder.Entity<Financeiro>().Ignore(a => a.Ong_Id);
            modelBuilder.Entity<Pessoa>().Ignore(a => a.Ong_Id);
            modelBuilder.Entity<Raca>().Ignore(a => a.Ong_Id);

            var ong = new Ong
            {
                Id = 1,
                Codigo = 1,
                Razao_Social = "AdminOng",
                Nome_Fantasia = "AdminOng",
                Cnpj = "01234567891234",
                Numero = 1,
                Bairro = "Centro",
                Logradouro = "Centro",
                Cep = "88802090",
                Cidade = "Circiuma",
                UF = "SC",
                Complemento = string.Empty
            };

            modelBuilder.Entity<Ong>().HasData(ong);

            modelBuilder.Entity<Usuario>().HasData(new
            {
                Id = 1,
                Nome = "Administrador",
                Login = "ADMINISTRADOR",
                Senha = "1234",
                Perfil = "ADMINISTRADOR",
                Ativo = 'Y',
                OngId = ong.Id
            });
      
        }
    }
}
