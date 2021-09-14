using Mansoura.Model;
using Mansoura.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mansoura.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {
        public Products(JsonFileIDataService service)
        {
            Service = service;
        }

        public JsonFileIDataService Service { get; }

        [HttpGet]
        public Members Get()
        {
            return Service.GetMembers();
        }

        [Route("Rate")]
        [HttpGet]

        public ActionResult AddRating([FromQuery]int memberId, [FromQuery] int rating)
        {
            Service.AddRating(memberId, rating);
            return Ok();
        }


    }
}
