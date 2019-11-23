using Microsoft.EntityFrameworkCore;

namespace CentralDeErros.Api.Models
{
    public class ErroDbContext : DbContext
    {
        public DbSet<Error> Errors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ErrorOcurrence> OcorrenciaErros { get; set; }
        public DbSet<Situacao> Situacoes { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Ambiente> Ambientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //esta configurado com o nome do meu banco, trocar para  testar
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-R629N29\SQLEXPRESS;Database=CentralDeErros;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(c => c.OcorrenciaErros).WithOne(e => e.User).IsRequired();
            //modelBuilder.Entity<OcorrenciaErro>().HasMany(c => c.Errors).WithOne(e => e.OcorrenciaErros).IsRequired();
            modelBuilder.Entity<Situacao>().HasMany(c => c.Errors).WithOne(e => e.Situacao).IsRequired();
            modelBuilder.Entity<Level>().HasMany(c => c.Errors).WithOne(e => e.Level).IsRequired();
            modelBuilder.Entity<Ambiente>().HasMany(c => c.Errors).WithOne(e => e.Ambiente).IsRequired();
            modelBuilder.Entity<Error>().HasKey(c => new { c.Situacao_Id, c.Ambiente_Id, c.Level_Id });//chave composta

        }



    }
}
