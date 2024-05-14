using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Tranfer.Domain.Interfaces;
using MicroRabbit.Tranfer.Domain.Models;
using MicroRabbit.Transfer.Application.Interfaces;


namespace MicroRabbit.Transfer.Application.Services
{
    public class TransfersService : ITransferService
    {
        private readonly ITransRepository _transRepository;
        private readonly IEventBus  _bus;
        public TransfersService(ITransRepository transRepository, IEventBus bus)
        {
            _transRepository = transRepository;
            _bus = bus;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transRepository.GetTransferLogs();
        }
    }
}
