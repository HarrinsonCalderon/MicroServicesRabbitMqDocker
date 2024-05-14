 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MicroRabbit.Tranfer.Data.Context;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Application.Services;
using System.Net.Mime;
using MicroRabbit.Tranfer.Domain.Interfaces;
using MicroRabbit.Tranfer.Data.Repository;
using MediatR;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//cadena de conexion
builder.Services.AddDbContext<TransferDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("TransferDbConnection")));

//IoC referencias e instancias hacia Ioc bus, domain, entity framework e inyecciones de sus repositorios
//DependencyContainer.RegisterServices(builder.Services, builder.Configuration);
builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQSettings"));
builder.Services.RegisterServices(builder.Configuration);


//Application services
builder.Services.AddTransient<ITransferService, TransfersService>();

//Data
builder.Services.AddTransient<ITransRepository, TransRepository>();
builder.Services.AddTransient<TransferDbContext>();



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
