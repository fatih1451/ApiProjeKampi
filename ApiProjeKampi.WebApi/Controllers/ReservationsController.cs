using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.ReservationDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public ReservationsController(ApiContext apiContext, IMapper mapper)
        {
            _context = apiContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ReservationList()
        {
            var values = _context.Reservations.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateReservation(CreateReservationDto createReservationDto)
        {
            var value = _mapper.Map<Reservation>(createReservationDto);
            _context.Reservations.Add(value);
            _context.SaveChanges();
            return Ok("Reservasyon ekleme işlemi başarılı!");
        }

        [HttpDelete]
        public IActionResult DeleteReservation(int id)
        {
            var Reservation = _context.Reservations.Find(id);
            if (Reservation == null)
            {
                return NotFound("Reservasyon bulunamadı.");
            }
            _context.Reservations.Remove(Reservation);
            _context.SaveChanges();
            return Ok("Reservasyon silme işlemi başarılı!");
        }

        [HttpGet("GetReservation")]
        public IActionResult GetReservation(int id)
        {
            var Reservation = _context.Reservations.Find(id);
            if (Reservation == null)
            {
                return NotFound("Reservasyon bulunamadı.");
            }
            return Ok(Reservation);
        }

        [HttpPut]
        public IActionResult UpdateReservation(UpdateReservationDto updateReservationDto)
        {
            var value = _mapper.Map<Reservation>(updateReservationDto);

            _context.Reservations.Update(value);
            _context.SaveChanges();
            return Ok("Reservasyon güncelleme işlemi başarılı!");
        }
    }
}
