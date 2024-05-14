using MediatR;
using MicroRabbit.Baking.Application.Interfaces;
using MicroRabbit.Baking.Application.Services;
using MicroRabbit.Baking.Data.Context;
using MicroRabbit.Baking.Data.Repository;
using MicroRabbit.Baking.Domain.CommandHandlers;
using MicroRabbit.Baking.Domain.Commands;
using MicroRabbit.Baking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Tranfer.Data.Context;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MicroRabbit.Infra.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //MediatR Mediator
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //Domain Bus
            services.AddTransient<IEventBus , RabbitMQBus>();

            ////Application services
            //services.AddTransient<IAccountServices, AccountServices>();
            //services.AddTransient<ITransferService, TransfersService>();

            ////Data
            //services.AddTransient<IAccountRepository, AccountRepository>();
            //services.AddTransient<BankingDbContext>();

            //services.AddTransient<ITransferService, TransfersService>();
            //services.AddTransient<TransferDbContext>();

            return services;
             

        }
    }
}
