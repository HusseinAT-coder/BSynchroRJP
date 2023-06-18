using BSynchro.Contracts.Accounts;
using BSynchro.Contracts.Customers;
using BSynchro.Contracts.Transactions;
using BSynchro.Infrastructure;
using BSynchro.Services.Accounts;
using BSynchro.Services.Customers;
using BSynchro.Services.Transactions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager Configuration = builder.Configuration; // allows both to access and to set up the config
IWebHostEnvironment environment = builder.Environment;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

builder.Services.AddDbContext<BSynchroDbContext>(
                options => options.UseSqlServer(
                    Configuration["ConnectionStrings:DefaultConnection"],
                    providerOptions =>
                    {
                        providerOptions.MigrationsAssembly("BSynchro.Infrastructure");
                        providerOptions.EnableRetryOnFailure();
                        providerOptions.UseNetTopologySuite();
                    }));

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
