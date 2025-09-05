using System;
using AlunosApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AlunosApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().HasData(
                new Aluno
                {
                    Id = 1,
                    Nome = "Arthur Pires",
                    Email = "arthurpires@gmail.com",
                    Idade = 18
                },
                new Aluno
                {
                    Id = 2,
                    Nome = "Luano Pires",
                    Email = "Luanopires@gmail.com",
                    Idade = 20
                }
            );
        }
     }
}
