using MediatR;
using MicroRabbit.Baking.Domain.Commands;
using MicroRabbit.Baking.Domain.Events;
using MicroRabbit.Domain.Core.Bus;

namespace MicroRabbit.Baking.Domain.CommandHandlers
{
    public class TransferCommandHandler: IRequestHandler<CreateTransferCommand,bool>
    {
        
        private readonly IEventBus _bus;

        public TransferCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            //logica para publicar el mensaje dentro del event  bus rabbitmq

            _bus.Publish(new TransferCreatedEvent(request.To,request.From,request.Amount));

            return Task.FromResult(true);
        }
    }
}
