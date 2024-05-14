using MicroRabbit.Tranfer.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace MicroRabbit.Tranfer.Data.Context
{
    public class TransferDbContext:DbContext
    {
        
        public TransferDbContext(DbContextOptions<TransferDbContext> options) : base(options)
        {

        }
        public DbSet<TransferLog> TransferLogs { get; set; }

    }
}

