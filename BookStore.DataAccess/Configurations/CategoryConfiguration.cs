using BookStore.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
             builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();

            //relationships
            //one to many: category --> Collection
            builder.HasMany(x => x.Collections)
                  .WithOne(x => x.Category)
                  .HasForeignKey(x => x.Category_Id)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Category");
        }
    }
}
