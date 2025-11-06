using GerenciamentoEscolarAPP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoEscolarAPP.Data
{
    public class EscolaContext : DbContext
    {
        // Construtor para uso com DbContextOptions (factory / DI / helper)
        public EscolaContext(DbContextOptions<EscolaContext> options) : base(options)
        {
        }

        // Construtor sem parâmetros (opcional) — mantém compatibilidade com código que fazia "new EscolaContext()"
        public EscolaContext() : base()
        {
        }

        // DbSets
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Nota> Notas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Só configura se não veio options já configurado
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\mssqllocaldb;Database=GerenciamentoEscolarDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nota>()
                .Property(n => n.Valor)
                .HasColumnType("decimal(5,2)");

            // Seed opcional (se quiser)
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Nome = "wendell", Email = "wendell@gmail.com", Senha = "123", Tipo = "Professor" },
                new Usuario { Id = 2, Nome = "Aluno Teste", Email = "aluno@escola.com", Senha = "123", Tipo = "Aluno" }
            );
        }
    }
}