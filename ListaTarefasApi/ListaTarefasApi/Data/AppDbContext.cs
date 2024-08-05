// Data/AppDbContext.cs

using Microsoft.EntityFrameworkCore;
using ListaTarefasApi.Models;

namespace ListaTarefasApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>()
                .HasOne(t => t.Status)
                .WithMany()
                .HasForeignKey(t => t.status_id);
        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}