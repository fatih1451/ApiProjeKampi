using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ApiContext _context;
        public TestimonialsController(ApiContext apiContext)
        {
            _context = apiContext;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _context.Testimonials.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial Testimonial)
        {
            _context.Testimonials.Add(Testimonial);
            _context.SaveChanges();
            return Ok("Referans ekleme işlemi başarılı!");
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var Testimonial = _context.Testimonials.Find(id);
            if (Testimonial == null)
            {
                return NotFound("Referans bulunamadı.");
            }
            _context.Testimonials.Remove(Testimonial);
            _context.SaveChanges();
            return Ok("Referans silme işlemi başarılı!");
        }

        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var Testimonial = _context.Testimonials.Find(id);
            if (Testimonial == null)
            {
                return NotFound("Referans bulunamadı.");
            }
            return Ok(Testimonial);
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial Testimonial)
        {
            _context.Testimonials.Update(Testimonial);
            _context.SaveChanges();
            return Ok("Referans güncelleme işlemi başarılı!");
        }
    }
}
