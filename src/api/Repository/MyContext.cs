using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Repository
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) {}

        // Adicionando models como DbSet
        public DbSet<Lead> Lead { get; set; } = null!;
        public DbSet<Registration> Registration { get; set; } = null!;
        public DbSet<Course> Course { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Verificamos se o banco de dados já foi configurado
            if (!optionsBuilder.IsConfigured)
            {
                // Buscamos o valor da connection string armazenada nas variáveis de ambiente
                var connectionString = Environment.GetEnvironmentVariable("DOTNET_CONNECTION_STRING");

                // Executamos o método UseSqlServer e passamos a connection string a ele
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {  
            mb.Entity<Registration>()
                .HasOne(c => c.Course)
                .WithMany(r => r.Registration)
                .HasForeignKey(r => r.IdCourse)
                .OnDelete(DeleteBehavior.Cascade);

            mb.Entity<Registration>()
                .HasOne(l => l.Lead)
                .WithMany(r => r.Registration)
                .HasForeignKey(r => r.IdLead)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}