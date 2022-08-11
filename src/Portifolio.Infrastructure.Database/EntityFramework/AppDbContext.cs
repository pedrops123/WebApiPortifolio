using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace Portifolio.Infrastructure.Database.EntityFramework
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.ConfigureDbContext();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
