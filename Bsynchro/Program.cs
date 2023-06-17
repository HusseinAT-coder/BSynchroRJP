using BSynchro.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager Configuration = builder.Configuration; // allows both to access and to set up the config
IWebHostEnvironment environment = builder.Environment;

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<BSynchroDbContext>(
                options => options.UseSqlServer(
                    Configuration["ConnectionStrings:DefaultConnection"],
                    providerOptions =>
                    {
                        providerOptions.MigrationsAssembly("Demo.EntityFrameworkCore");
                        providerOptions.EnableRetryOnFailure();
                        providerOptions.UseNetTopologySuite();
                    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
