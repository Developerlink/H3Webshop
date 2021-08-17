using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.Interfaces;
using ElectronicsORM.Library.Repositories.MO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "The server is running...";
        }
    }
}
