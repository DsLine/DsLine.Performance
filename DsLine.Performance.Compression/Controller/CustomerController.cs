using DsLine.Performance.Compression.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Text.Json;

namespace DsLine.Performance.Compression.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly IHostEnvironment  _hostingEnvironment;

        public CustomerController(IHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Customer>> Get()
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            var JSON = System.IO.File.ReadAllText(contentRootPath + "/CustomerData.json");
            List<Customer>  listCustoemr=JsonSerializer.Deserialize<List<Customer>>(JSON);
            return Ok(listCustoemr);
        }
    }
}
