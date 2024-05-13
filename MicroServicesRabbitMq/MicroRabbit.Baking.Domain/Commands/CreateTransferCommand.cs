using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Baking.Domain.Commands
{
    public  class CreateTransferCommand : TansferCommand
    {
        public CreateTransferCommand(int from, int to, decimal amount) { 
            From= from; 
            To= to;
            Amount= amount;
        }  
    }
}
