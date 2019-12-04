﻿using Microsoft.EntityFrameworkCore;

namespace CentralDeErros.Api.Models
{
    public class ErrorDbContext : DbContext
    {
        public DbSet<Error> Errors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ErrorOccurrence> ErrorOccurrences { get; set; }
        public DbSet<Situation> Situations { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Environment> Environments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-R629N29\SQLEXPRESS;Database=CentralDeErros;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.ErrorOccurrences).WithOne(u => u.User).IsRequired();
            modelBuilder.Entity<Situation>().HasMany(s => s.Errors).WithOne(s => s.Situation).IsRequired();
            modelBuilder.Entity<Level>().HasMany(l => l.Errors).WithOne(l => l.Level).IsRequired();
            modelBuilder.Entity<Environment>().HasMany(e => e.Errors).WithOne(e => e.Environment).IsRequired();
            modelBuilder.Entity<Error>().HasKey(e => new { e.SituationId, e.EnvironmentId, e.LevelId });//chave composta

        }



    }
}