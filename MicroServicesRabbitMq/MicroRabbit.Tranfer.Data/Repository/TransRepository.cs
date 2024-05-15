using MicroRabbit.Tranfer.Data.Context;
using MicroRabbit.Tranfer.Domain.Interfaces;
using MicroRabbit.Tranfer.Domain.Models;
 

namespace MicroRabbit.Tranfer.Data.Repository
{
    public class TransRepository : ITransRepository
    {
        private readonly TransferDbContext _context;

        public TransRepository(TransferDbContext context)
        {
            _context = context;
        }

        public void AddTransferLog(TransferLog log)
        {
            _context.Add(log);
            _context.SaveChanges(); 
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _context.TransferLogs;
        }
    }
}
