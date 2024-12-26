using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configurations
{

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories").HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("CategoryID");
            builder.Property(c => c.Name).HasMaxLength(100);


            builder.HasMany(c => c.Subcategories)
                   .WithOne(c => c.ParentCategory)
                   .HasForeignKey("ParentCategoryId")
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(c => c.Products)
                   .WithOne(p => p.Category)
                   .HasForeignKey("CategoryId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
