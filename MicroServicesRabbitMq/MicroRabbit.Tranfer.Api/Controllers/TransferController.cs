using MicroRabbit.Tranfer.Domain.Models;
using MicroRabbit.Transfer.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Tranfer.Api.Controllers
{
    [Route("api/[controller]")]
    public class TransferController:ControllerBase
    {
        private readonly ITransferService _itransferService;

        public TransferController(ITransferService itransferService)
        {
            _itransferService = itransferService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TransferLog>> Get()
        {
            return Ok(_itransferService.GetTransferLogs());
        } 
    }
}
