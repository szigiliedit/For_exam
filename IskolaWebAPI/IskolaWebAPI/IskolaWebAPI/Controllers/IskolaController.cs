using IskolaWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IskolaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IskolaController : ControllerBase
    {
        [HttpGet]

        public IActionResult GetIskolak()
        {
            using (var context = new versenyContext())
            {
                try
                {
                    return StatusCode(200, context.Iskolaks.ToList());
                }
                catch (Exception ex)
                {
                   
                    return BadRequest(ex.Message);
                }
            }
        }



    }
}
