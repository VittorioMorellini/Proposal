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
    [Route("product")]
    public class ProductController : Controller
    {
        private IProductService service;
        public ProductController(IProductService service)
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

        [HttpPost("search")]
        public IActionResult Search([FromBody] ProductSearchModel model)
        {
            try
            {
                return new OkObjectResult(service.Search(model));
            }
            catch (Exception ex)
            {
                var innerMsg = ex.InnerException != null ? (" " + ex.InnerException.Message) : "";
                return new BadRequestObjectResult($"{ex.Message}{innerMsg}");
            }
        }

        [HttpPost]
        public IActionResult Save([FromBody] Product item)
        {
            try
            {
                return new OkObjectResult(service.Save(item.Id, item));
            }
            catch (Exception ex)
            {
                var innerMsg = ex.InnerException != null ? (" " + ex.InnerException.Message) : "";
                return new BadRequestObjectResult($"{ex.Message}{innerMsg}");
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] long id)
        {
            try
            {
                return new OkObjectResult(service.Delete(id));
            }
            catch (Exception ex)
            {
                var innerMsg = ex.InnerException != null ? (" " + ex.InnerException.Message) : "";
                return new BadRequestObjectResult($"{ex.Message}{innerMsg}");
            }
        }
    }
}
