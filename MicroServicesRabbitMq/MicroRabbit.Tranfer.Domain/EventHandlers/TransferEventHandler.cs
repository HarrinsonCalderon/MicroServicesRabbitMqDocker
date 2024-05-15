using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Tranfer.Domain.Events;

namespace MicroRabbit.Tranfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    { 

        public TransferEventHandler()
        {

        }
        //Este evento se dispara cuando consuma el mensaje de la queue de banking
        public Task Handle(TransferCreatedEvent @event)
        {
            return Task.CompletedTask;
        }

       
    }
}
