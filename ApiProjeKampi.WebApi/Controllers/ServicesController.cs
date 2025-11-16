using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _context;
        public ServicesController(ApiContext apiContext)
        {
            _context = apiContext;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _context.Services.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Hizmet ekleme işlemi başarılı!");
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var Service = _context.Services.Find(id);
            if (Service == null)
            {
                return NotFound("Hizmet bulunamadı.");
            }
            _context.Services.Remove(Service);
            _context.SaveChanges();
            return Ok("Hizmet silme işlemi başarılı!");
        }

        [HttpGet("GetService")]
        public IActionResult GetService(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null)
            {
                return NotFound("Hizmet bulunamadı.");
            }
            return Ok(service);
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            //var existingService = _context.Services.Find(Service.ServiceId);
            //if (existingService == null)
            //{
            //    return NotFound("Hizmet bulunamadı.");
            //}
            //existingService.ServiceName = Service.ServiceName;
            //_context.SaveChanges();
            //return Ok("Hizmet güncelleme işlemi başarılı!");

            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Hizmet güncelleme işlemi başarılı!");
        }
    }
}
