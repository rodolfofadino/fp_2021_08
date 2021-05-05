using Fiap.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Persistence.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Status> Status { get; set; }

        //N:N

    }
}
