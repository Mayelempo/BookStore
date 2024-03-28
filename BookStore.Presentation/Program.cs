using BookStore.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.ConfigureApplicationServices(builder.Configuration);
var app = builder.Build();
app.Configure();
