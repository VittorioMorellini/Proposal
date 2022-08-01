using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Proposal.Core.Services;
using Proposal.Core.Utils;
using Proposal.Core.Models;

namespace Proposal.Api.Controllers
{
    [Route("warehouse")]
    public class WarehouseController : Controller
    {
        private IWarehouseService service;
        public WarehouseController(IWarehouseService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public IActionResult Find(long id)
        {
            try
            {
                return new OkObjectResult(service.Find(id));
            }
            catch (Exception ex)
            {
                var innerMsg = ex.InnerException != null ? (" " + ex.InnerException.Message) : "";
                return new BadRequestObjectResult($"{ex.Message}{innerMsg}");
            }
        }

        [HttpPost("balance")]
        public IActionResult GetBalance([FromBody] WarehouseSearchModel model)
        {
            try
            {
                return new OkObjectResult(service.GetBalance(model));
            }
            catch (Exception ex)
            {
                var innerMsg = ex.InnerException != null ? (" " + ex.InnerException.Message) : "";
                return new BadRequestObjectResult($"{ex.Message}{innerMsg}");
            }
        }

    }
}
