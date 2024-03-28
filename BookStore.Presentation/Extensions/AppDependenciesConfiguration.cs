using Microsoft.AspNetCore.Diagnostics;
using BookStore.DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Presentation.Extensions
{
    public static partial class AppDependenciesConfiguration
    {
        public static WebApplicationBuilder ConfigureApplicationServices(this WebApplicationBuilder builder, IConfiguration configuration)
        {
            builder.Services.AddIdentityServiceConfiguration(x =>
            {
                x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //add services  , profiles etc
            builder.Services.AddExceptionHandler(options =>
            {
                options.ExceptionHandlingPath = "/Error";

            });
            builder.Services.AddMvc();
            //builder.Services.Configure<MySettingsModel>(Configuration.GetSection("MySettings"));
            return builder;
        }

        public static void Configure(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();
            app.MapControllers();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
