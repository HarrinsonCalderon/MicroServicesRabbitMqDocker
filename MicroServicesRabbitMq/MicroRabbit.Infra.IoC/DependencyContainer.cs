using MediatR;
using MicroRabbit.Baking.Application.Interfaces;
using MicroRabbit.Baking.Application.Services;
using MicroRabbit.Baking.Data.Context;
using MicroRabbit.Baking.Data.Repository;
using MicroRabbit.Baking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MicroRabbit.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //MediatR Mediator
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //Domain Bus
            services.AddTransient<IEventBus , RabbitMQBus>();
            services.Configure<RabbitMQSettings>(c => configuration.GetSection("RabbitMQSettings"));

            //Application services
            services.AddTransient<IAccountServices, AccountServices>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();

             

        }
    }
}
