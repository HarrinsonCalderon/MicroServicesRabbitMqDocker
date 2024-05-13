using MicroRabbit.Infra.IoC;
using MicroRabbit.Baking.Data.Context;
using Microsoft.EntityFrameworkCore;
using MicroRabbit.Infra.Bus;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//cadena de conexion
builder.Services.AddDbContext<BankingDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("BackingDbConnection")));

//IoC referencias e instancias hacia Ioc bus, domain, entity framework e inyecciones de sus repositorios
//DependencyContainer.RegisterServices(builder.Services, builder.Configuration);
builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQSettings"));
builder.Services.RegisterServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//agregar para las cors
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
