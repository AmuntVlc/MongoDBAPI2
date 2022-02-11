using Microsoft.AspNetCore.Mvc;
using MongoDBAPI2.Models;
using MongoDBAPI2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBAPI2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CiudadesController : Controller
    {
        private readonly CiudadesService _ciudadesService;

        public CiudadesController(CiudadesService ciudadesService) =>
            _ciudadesService = ciudadesService;
        [HttpGet]
        public async Task<List<Ciudad>> Get() =>
           await _ciudadesService.GetAsync();
    }
}
