using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();

            //Relationships
            //One to many : Book --> Likes
            builder.HasMany(x => x.Likes)
                   .WithOne(x => x.Book)
                   .HasForeignKey(x => x.Book_Id)
                   .OnDelete(DeleteBehavior.Cascade);

            //One to many : Book --> Comments
            builder.HasMany(x => x.Comments)
                   .WithOne(x => x.Book)
                   .HasForeignKey(x => x.Book_Id)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Books");
        }
    }
}
