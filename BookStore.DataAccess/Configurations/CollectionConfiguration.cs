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
    public class CollectionConfiguration : IEntityTypeConfiguration<Collection>
    {
        public void Configure(EntityTypeBuilder<Collection> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Tags).IsRequired();

            //Relationships
            //One To Many Collections --> Books
            builder.HasMany(x => x.Books)
           .WithOne(x => x.Collection)
           .HasForeignKey(x => x.Collection_Id)
           .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Collections");
        }
    }
}
