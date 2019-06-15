﻿// <auto-generated />
using System;
using AdotaPet.WebApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdotaPet.WebApp.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190614024532_teste")]
    partial class teste
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdotaPet.WebApp.Models.Entities.Adocao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo");

                    b.Property<DateTime>("Data_Cadastro");

                    b.Property<DateTime>("Data_Finalizacao");

                    b.Property<int>("Pessoa_IdId");

                    b.HasKey("Id");

                    b.HasIndex("Pessoa_IdId");

                    b.ToTable("Adocao");
                });

            modelBuilder.Entity("AdotaPet.WebApp.Models.Entities.Adocao_Itens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Adocao_IdId");

                    b.Property<int>("Animal_IdId");

                    b.HasKey("Id");

                    b.HasIndex("Adocao_IdId");

                    b.HasIndex("Animal_IdId");

                    b.ToTable("Adocao_Itens");
                });

            modelBuilder.Entity("AdotaPet.WebApp.Models.Entities.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Castrado")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<int>("Codigo");

                    b.Property<int>("Doenca_IdId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<short>("Porte");

                    b.Property<int>("Raca_IdId");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("Vacina")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("Vermifugado")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.HasKey("Id");

                    b.HasIndex("Doenca_IdId");

                    b.HasIndex("Raca_IdId");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("AdotaPet.WebApp.Models.Entities.ControleAcompanhamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo");

                    b.Property<DateTime>("Data_Cadastro");

                    b.Property<int?>("Ong_IdId");

                    b.Property<int?>("Pessoa_IdId");

                    b.Property<string>("descricao");

                    b.Property<string>("status");

                    b.HasKey("Id");

                    b.HasIndex("Ong_IdId");

                    b.HasIndex("Pessoa_IdId");

                    b.ToTable("ControleAcompanhamento");
                });

            modelBuilder.Entity("AdotaPet.WebApp.Models.Entities.Doenca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Doenca");
                });

            modelBuilder.Entity("AdotaPet.WebApp.Models.Entities.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Complemento")
                        .HasMaxLength(200);

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("Numero");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("AdotaPet.WebApp.Models.Entities.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo");

                    b.Property<DateTime>("Data_evento");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<int>("Ong_IdId");

                    b.HasKey("Id");

                    b.HasIndex("Ong_IdId");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("AdotaPet.WebApp.Models.Entities.Financeiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data_movimentacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Entrada_saida")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.ToTable("Financeiro");
                });

            modelBuilder.Entity("AdotaPet.WebApp.Models.Entities.LarTemporario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Animal_IdId");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("Codigo");

                    b.Property<string>("Complemento")
                        .HasMaxLength(200);

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("Numero");

                    b.Property<string>("Observacao")
                        .HasMaxLength(200);

                    b.Property<int>("Ong_IdId");

                    b.Property<int>("Pessoa_IdId");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.HasIndex("Animal_IdId");

                    b.HasIndex("Ong_IdId");

                    b.HasIndex("Pessoa_IdId");

                    b.ToTable("LarTemporario");
                });

            modelBuilder.Entity("AdotaPet.WebApp.Models.Entities.Ong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(18);

                    b.Property<int>("Codigo");

                    b.Property<string>("Complemento")
                        .HasMaxLength(200);

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Nome_Fantasia")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("Numero");

                    b.Property<string>("Razao_Social")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("Ong");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bairro = "Centro",
                            Cep = "88802090",
                            Cidade = "Circiuma",
                            Cnpj = "01234567891234",
                            Codigo = 1,
                            Complemento = "",
                            Logradouro = "Centro",
                            Nome_Fantasia = "AdminOng",
                            Numero = 1,
                            Razao_Social = "AdminOng",
                            UF = "SC"
                        });
                });

            modelBuilder.Entity("AdotaPet.WebApp.Models.Entities.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("Codigo");

                    b.Property<string>("Complemento")
                        .HasMaxLength(200);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14);

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("Numero");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("AdotaPet.WebApp.Models.Entities.Raca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Observacao")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Raca");
                });

            modelBuilder.Entity("AdotaPet.WebApp.Models.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ativo")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("OngId");

                    b.Property<string>("Perfil")
                        .HasMaxLength(15);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("OngId");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = "Y",
                            Login = "ADMINISTRADOR",
                            Nome = "Administrador",
                            OngId = 1,
                            Perfil = "ADMINISTRADOR",
                            Senha = "1234"
                        });
                });

            modelBuilder.Entity("AdotaPet.WebApp.Models.Entities.Adocao", b =>
                {
                    b.HasOne("AdotaPet.WebApp.Models.Entities.Pessoa", "Pessoa_Id")
                        .WithMany()
                        .HasForeignKey("Pessoa_IdId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdotaPet.WebApp.Models.Entities.Adocao_Itens", b =>
                {
                    b.HasOne("AdotaPet.WebApp.Models.Entities.Adocao", "Adocao_Id")
                        .WithMany()
                        .HasForeignKey("Adocao_IdId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AdotaPet.WebApp.Models.Entities.Animal", "Animal_Id")
                        .WithMany()
                        .HasForeignKey("Animal_IdId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdotaPet.WebApp.Models.Entities.Animal", b =>
                {
                    b.HasOne("AdotaPet.WebApp.Models.Entities.Doenca", "Doenca_Id")
                        .WithMany()
                        .HasForeignKey("Doenca_IdId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AdotaPet.WebApp.Models.Entities.Raca", "Raca_Id")
                        .WithMany()
                        .HasForeignKey("Raca_IdId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdotaPet.WebApp.Models.Entities.ControleAcompanhamento", b =>
                {
                    b.HasOne("AdotaPet.WebApp.Models.Entities.Ong", "Ong_Id")
                        .WithMany()
                        .HasForeignKey("Ong_IdId");

                    b.HasOne("AdotaPet.WebApp.Models.Entities.Pessoa", "Pessoa_Id")
                        .WithMany()
                        .HasForeignKey("Pessoa_IdId");
                });

            modelBuilder.Entity("AdotaPet.WebApp.Models.Entities.Evento", b =>
                {
                    b.HasOne("AdotaPet.WebApp.Models.Entities.Ong", "Ong_Id")
                        .WithMany()
                        .HasForeignKey("Ong_IdId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdotaPet.WebApp.Models.Entities.LarTemporario", b =>
                {
                    b.HasOne("AdotaPet.WebApp.Models.Entities.Animal", "Animal_Id")
                        .WithMany()
                        .HasForeignKey("Animal_IdId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AdotaPet.WebApp.Models.Entities.Ong", "Ong_Id")
                        .WithMany()
                        .HasForeignKey("Ong_IdId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AdotaPet.WebApp.Models.Entities.Pessoa", "Pessoa_Id")
                        .WithMany()
                        .HasForeignKey("Pessoa_IdId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdotaPet.WebApp.Models.Entities.Usuario", b =>
                {
                    b.HasOne("AdotaPet.WebApp.Models.Entities.Ong", "Ong")
                        .WithMany()
                        .HasForeignKey("OngId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}