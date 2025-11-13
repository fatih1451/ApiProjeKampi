using ApiProjeKampi.WebApi.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiProjeKampi.WebApi.Entities;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ChefsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ChefsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]   
        public IActionResult ChefList()
        {
            var values = _context.Chefs.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        {
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Şef ekleme işlemi başarılı!");
        }

        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var chef = _context.Chefs.Find(id);
            if (chef == null)
            {
                return NotFound("Şef bulunamadı.");
            }
            _context.Chefs.Remove(chef);
            _context.SaveChanges();
            return Ok("Şef silme işlemi başarılı!");
        }

        [HttpGet("GetChef")]
        public IActionResult GetChef(int id)
        {
            var chef = _context.Chefs.Find(id);
            if (chef == null)
            {
                return NotFound("Şef bulunamadı.");
            }
            return Ok(chef);
        }

        [HttpPut]
        public IActionResult UpdateChef(Chef chef)
        {
            //var existingChef = _context.Chefs.Find(chef.ChefId);
            //if (existingChef == null)
            //{
            //    return NotFound("Şef bulunamadı.");
            //}
            //existingChef.Name = chef.Name;
            //existingChef.Specialty = chef.Specialty;
            // Diğer alanları da güncelleyin


            _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("Şef güncelleme işlemi başarılı!");
        }
    }

}
