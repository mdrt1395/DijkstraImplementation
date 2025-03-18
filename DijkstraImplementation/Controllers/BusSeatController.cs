using DijkstraImplementation.Data;
using DijkstraImplementation.Models.DTOs.BusSeatDTOs;
using DijkstraImplementation.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DijkstraImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusSeatController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public BusSeatController(AppDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllSeats() 
        {
            var allSeats = dbContext.BusSeats.ToList();
            return Ok(allSeats);
        }

        [HttpGet]
        [Route("{SeatNumber:int}")]
        public IActionResult GetSeatBySeatNumber(int SeatNumber) 
        {
            var busSeat = dbContext.BusSeats.Find(SeatNumber);
            if (busSeat != null) 
            {
                return NotFound();
            }
            return Ok(busSeat);
        }

        [HttpPost]
        public IActionResult AddBusSeat(AddBusSeatDto addBusSeatDto)
        {
            var busSeat = new BusSeat()
            {
                SeatNumber = addBusSeatDto.SeatNumber,
            };
            dbContext.BusSeats.Add(busSeat);
            dbContext.SaveChanges();
            return Ok(busSeat);
        }

        [HttpDelete]
        [Route("{SeatNumber:int}")]
        public IActionResult DeleteBusSeat(int SeatNumber) 
        {
            var busSeat = dbContext.BusSeats.Find(SeatNumber);
            if (busSeat != null) 
            {
                return NotFound();
            }
            dbContext.BusSeats.Remove(busSeat);
            dbContext.SaveChanges();
            return Ok(busSeat);
        }

    }
}
