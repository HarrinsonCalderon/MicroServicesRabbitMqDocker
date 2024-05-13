using MicroRabbit.Baking.Application.Models;
using MicroRabbit.Baking.Domain.Models;


namespace MicroRabbit.Baking.Application.Interfaces
{
    public  interface IAccountServices
    {
        IEnumerable<Account> GetAccounts();
        void Transfer(AccountTransfer accountTransfer);
    }
}
