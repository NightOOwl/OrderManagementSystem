using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CatalogService.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql(_configuration.GetConnectionString("Postgres"))
                .UseLoggerFactory(CreateLoggerFactory())
                .EnableSensitiveDataLogging();
        }

        public ILoggerFactory CreateLoggerFactory() =>
              LoggerFactory.Create(builber => { builber.AddConsole(); });
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
