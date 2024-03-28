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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);  
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Password).IsRequired();

            //Relationships
            //One To Many  user ---> collections
            builder.HasMany(x => x.Collections)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.User_Id)
                   .OnDelete(DeleteBehavior.Cascade);

            //One To Many  user ---> likes
            builder.HasMany(x => x.Likes)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.User_Id)
                   .OnDelete(DeleteBehavior.Cascade);

            //One To Many  user ---> Comments
            builder.HasMany(x => x.Comments)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.User_Id)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("User");
        }
    }
}
