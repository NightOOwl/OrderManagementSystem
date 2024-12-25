using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("ProductID");
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(1000);

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products) 
                   .HasForeignKey("CategoryId") 
                   .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
