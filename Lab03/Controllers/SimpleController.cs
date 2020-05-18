using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab03.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SimpleController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Status OK";
        }
    }
}