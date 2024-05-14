using MicroRabbit.Tranfer.Domain.Models;
 
namespace MicroRabbit.Tranfer.Domain.Interfaces
{
    public interface ITransRepository
    {
        IEnumerable<TransferLog> GetTransferLogs();
    }
}
