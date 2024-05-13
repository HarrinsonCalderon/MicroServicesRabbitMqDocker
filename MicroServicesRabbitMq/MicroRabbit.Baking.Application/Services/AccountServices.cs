using MicroRabbit.Baking.Application.Interfaces;
using MicroRabbit.Baking.Application.Models;
using MicroRabbit.Baking.Domain.Commands;
using MicroRabbit.Baking.Domain.Interfaces;
using MicroRabbit.Baking.Domain.Models;
using MicroRabbit.Domain.Core.Bus;

namespace MicroRabbit.Baking.Application.Services
{
    public class AccountServices:IAccountServices
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;
        public AccountServices(IAccountRepository accountRepository,IEventBus bus)
        {
            _accountRepository = accountRepository;
            _bus = bus;
        }

        public IEnumerable<Account> GetAccounts() 
        {
            return _accountRepository.GetAccounts();
        }
        public void Transfer( AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                accountTransfer.FromAccount,
                accountTransfer.ToAccount,
                accountTransfer.TransferAmount);
            _bus.SendCommand(createTransferCommand);
        }
    }
}
