using MicroRabbit.Baking.Application.Interfaces;
using MicroRabbit.Baking.Application.Models;
using MicroRabbit.Baking.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Baking.Api.Controllers
{
    [Route("api/[controller]")]
    public class BakingController:ControllerBase
    {
        private readonly IAccountServices _accountServices;
        public BakingController(IAccountServices accountServices)
        {
            _accountServices= accountServices;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            return Ok(_accountServices.GetAccounts());
        }
        [HttpPost]
        public ActionResult<IEnumerable<Account>> Post([FromBody] AccountTransfer accountTransfer)
        {
            _accountServices.Transfer(accountTransfer);
            return Ok(accountTransfer);
        }

    }
}
