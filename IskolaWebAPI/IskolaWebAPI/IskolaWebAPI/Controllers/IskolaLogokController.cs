using IskolaWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IskolaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IskolaLogokController : ControllerBase
    {
        private readonly versenyContext context = new();

        [HttpDelete]

        public IActionResult DeleteIskolalogo(int id)
        {
            try
            {
                Iskolalogok iskolalogo = context.Iskolalogoks
                    .First(iskolalogo => iskolalogo.Id == id);

                context.Remove(iskolalogo);
                context.SaveChanges();
                return StatusCode(201, "Iskolalogo törlése sikeresen megtörtént");
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
