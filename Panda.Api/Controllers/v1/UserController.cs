using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Panda.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet]
        public string Get(int id)
        {
            return "this is v1 api"; 
        }
    }
}
