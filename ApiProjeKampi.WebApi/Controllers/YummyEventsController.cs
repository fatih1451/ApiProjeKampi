using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YummyEventsController : ControllerBase
    {
        private readonly ApiContext _context;
        public YummyEventsController(ApiContext apiContext)
        {
            _context = apiContext;
        }

        [HttpGet]
        public IActionResult YummyEventList()
        {
            var values = _context.YummyEvents.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateYummyEvent(YummyEvent YummyEvent)
        {
            _context.YummyEvents.Add(YummyEvent);
            _context.SaveChanges();
            return Ok("Etkinlik ekleme işlemi başarılı!");
        }

        [HttpDelete]
        public IActionResult DeleteYummyEvent(int id)
        {
            var YummyEvent = _context.YummyEvents.Find(id);
            if (YummyEvent == null)
            {
                return NotFound("Etkinlik bulunamadı.");
            }
            _context.YummyEvents.Remove(YummyEvent);
            _context.SaveChanges();
            return Ok("Etkinlik silme işlemi başarılı!");
        }

        [HttpGet("GetYummyEvent")]
        public IActionResult GetYummyEvent(int id)
        {
            var YummyEvent = _context.YummyEvents.Find(id);
            if (YummyEvent == null)
            {
                return NotFound("Etkinlik bulunamadı.");
            }
            return Ok(YummyEvent);
        }

        [HttpPut]
        public IActionResult UpdateYummyEvent(YummyEvent YummyEvent)
        {
            _context.YummyEvents.Update(YummyEvent);
            _context.SaveChanges();
            return Ok("Etkinlik güncelleme işlemi başarılı!");
        }
    }
}
