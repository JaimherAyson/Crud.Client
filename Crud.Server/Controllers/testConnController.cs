using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Crud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testConnController : ControllerBase
    {
        [HttpGet("getdata")]
        public IActionResult GetData()
        {
            return Ok(new
            {
                Message = "Hello from the server!",
                Timestamp = DateTime.UtcNow
            });        
        }
    }
}
