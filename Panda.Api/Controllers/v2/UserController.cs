using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Panda.Api.Controllers.v2
{
    [ApiVersion("2")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet]
        public string Get(int id)
        {
            return "this is v2 api";
        }
    }
}
