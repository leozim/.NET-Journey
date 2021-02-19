using Alura.CoisasAFazer.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Alura.CoisasAFazer.Testes.Infrastructure
{
    public class DbTarefasContextFake : DbContext
    {
        public DbTarefasContextFake(DbContextOptions options) : base(options)
        {

        }

        public DbTarefasContextFake(){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseInMemoryDatabase("DbTarefasContextFake");
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}