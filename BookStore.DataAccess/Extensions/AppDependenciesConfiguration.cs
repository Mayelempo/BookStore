using BookStore.DataAccess.DataContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Interfaces;
using BookStore.DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace BookStore.DataAccess.Extensions
{
    public static class AppDependenciesConfiguration
    {
        public static IServiceCollection AddIdentityServiceConfiguration(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContextPool<DatabaseContext>(options)
                .AddIdentity<User, IdentityRole>(option =>
                {
                    option.User.RequireUniqueEmail = true;
                    option.Password.RequireDigit = true;
                    option.Password.RequireLowercase = false;
                    option.Password.RequireUppercase = false;
                    option.Password.RequireNonAlphanumeric = false;
                    option.Password.RequiredLength = 15;
                })
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();

            return services;  
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped<ICollectionRepository, CollectionRepository>()
                           .AddScoped<ICategoryRepository, CategoryRepository>()
                           .AddScoped<IBookRepository, BookRepository>()
                           .AddScoped<ILikeRepository, LikeRepository>()
                           .AddScoped<ICommentRepository, CommentRepository>()
                           .AddScoped<ISaveChangesRepository,SaveChangesRepository>() ;         
        }
    }
}
