using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab03.Controllers
{
    [Route("signin-google")]
    [ApiController]
    public class signingoogleController : ControllerBase
    {
        [HttpGet]
        public string Authorized()
        {
            return "Authorized";
        }
    }
}