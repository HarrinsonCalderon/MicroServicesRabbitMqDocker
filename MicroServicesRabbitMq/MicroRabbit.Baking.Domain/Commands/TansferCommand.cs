using MicroRabbit.Domain.Core.Commands;

namespace MicroRabbit.Baking.Domain.Commands
{
    public abstract class TansferCommand : Command
    {
        public int From { get; set; }
        public int To { get; set; }
        public decimal Amount { get; protected set; }
    }
}
