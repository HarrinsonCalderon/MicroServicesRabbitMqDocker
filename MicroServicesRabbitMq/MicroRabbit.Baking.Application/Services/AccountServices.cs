using MicroRabbit.Baking.Application.Interfaces;
using MicroRabbit.Baking.Domain.Interfaces;
using MicroRabbit.Baking.Domain.Models;

namespace MicroRabbit.Baking.Application.Services
{
    public class AccountServices:IAccountServices
    {
        private readonly IAccountServices _accountRepository;

        public AccountServices(IAccountServices accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IEnumerable<Account> GetAccounts() 
        {
            return _accountRepository.GetAccounts();
        }
    }
}
