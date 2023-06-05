using IskolaWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IskolaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiakokController : ControllerBase
    {
        private readonly versenyContext context = new();

        [HttpPost]
        public IActionResult AddDiak(DiakokDto ujdiak) 
        {
            try
            {
                Diakok diak = new()
                {
                    Id = ujdiak.Id,
                    Tanev = ujdiak.Tanev,
                    IskolaId = ujdiak.IskolaId,
                    OktatasiAzonosito = ujdiak.OktatasiAzonosito,
                    Nev = ujdiak.Nev,
                    Osztaly = ujdiak.Osztaly
                };

                context.Diakoks.Add(diak);
                context.SaveChanges();
                return StatusCode(201, "A diák hozzáadása sikeresen megtörtént");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
