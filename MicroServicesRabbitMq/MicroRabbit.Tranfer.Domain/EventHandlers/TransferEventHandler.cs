using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Tranfer.Domain.Events;
using MicroRabbit.Tranfer.Domain.Interfaces;
using MicroRabbit.Tranfer.Domain.Models;

namespace MicroRabbit.Tranfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransRepository transRepository;

     
        public TransferEventHandler(ITransRepository transRepository)
        {
            this.transRepository = transRepository;
        }
        //Este evento se dispara cuando consuma el mensaje de la queue de banking
        public Task Handle(TransferCreatedEvent @event)
        {
            var transaction = new TransferLog
            {
                FromAccount = @event.From,
                ToAccount = @event.To,
                TransferAmount = @event.Amount
            };
            transRepository.AddTransferLog(transaction);
            return Task.CompletedTask;
        }

       
    }
}
