using CadastroLivros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Assunto> Assuntos { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<LivroAssunto> LivroAssuntos { get; set; }
        public DbSet<LivroAutor> LivroAutores { get; set; }
        public DbSet<PrecoLivro> PrecosLivros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasKey(l => l.Id);

                entity.Property(l => l.Titulo)
                    .HasMaxLength(40)
                    .IsRequired();

                entity.Property(l => l.Editora)
                    .HasMaxLength(40)
                    .IsRequired();

                entity.Property(l => l.Edicao)
                    .IsRequired();

                entity.Property(l => l.AnoPublicacao)
                    .HasMaxLength(4)
                    .IsRequired();
            });

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Nome)
                    .HasMaxLength(40)
                    .IsRequired();
            });

            modelBuilder.Entity<Assunto>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Descricao)
                    .HasMaxLength(20)
                    .IsRequired();
            });

            modelBuilder.Entity<PrecoLivro>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.TipoCompra)
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property(p => p.Valor)
                    .HasColumnType("decimal(10,2)")
                    .IsRequired();

                entity.HasOne(p => p.Livro)
                    .WithMany(l => l.Precos)
                    .HasForeignKey(p => p.LivroId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<LivroAutor>(entity =>
            {
                entity.HasKey(la => new { la.LivroId, la.AutorId });

                entity.HasOne(la => la.Livro)
                    .WithMany(l => l.Autores)
                    .HasForeignKey(la => la.LivroId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(la => la.Autor)
                    .WithMany(a => a.LivrosAutores)
                    .HasForeignKey(la => la.AutorId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<LivroAssunto>(entity =>
            {
                entity.HasKey(la => new { la.LivroId, la.AssuntoId });

                entity.HasOne(la => la.Livro)
                    .WithMany(l => l.Assuntos)
                    .HasForeignKey(la => la.LivroId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(la => la.Assunto)
                    .WithMany(a => a.LivrosAssuntos)
                    .HasForeignKey(la => la.AssuntoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
