using DijkstraImplementation.Data;
using DijkstraImplementation.Models.DTOs.BusScheduleDTOs;
using DijkstraImplementation.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DijkstraImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusScheduleController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public BusScheduleController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllBusSchedules()
        {
            var allBusSchedules = dbContext.BusSchedules.ToList();
            return Ok(allBusSchedules);
        }

        [HttpGet]
        [Route("{BusScheduleId:regex([[A-Za-z0-9!@#$%^&*()-_=+]])}")]
        public IActionResult GetBusScheduleById(string BusScheduleId)
        {
            var schedule = dbContext.BusSchedules.Find(BusScheduleId);
            if (schedule == null)
            {
                return NotFound();
            }
            return Ok(schedule);
        }

        [HttpPost]
        public IActionResult AddBusSchedule(AddBusScheduleDto addBusScheduleDto)
        {
            var busScheduleEntity = new BusSchedule()
            {
                BusScheduleId = addBusScheduleDto.BusScheduleId,
                DepartureTime = addBusScheduleDto.DepartureTime,
                ArrivalTime = addBusScheduleDto.ArrivalTime,
            };
            dbContext.BusSchedules.Add(busScheduleEntity);
            dbContext.SaveChanges();
            return Ok(busScheduleEntity);
        }

        [HttpPut]
        [Route("{BusScheduleId:regex([[A-Za-z0-9!@#$%^&*()-_=+]])}")]
        public IActionResult UpdateBusSchedule (UpdateBusScheduleDto updateBusScheduleDto)
        {
            var busSchedule = dbContext.BusSchedules.Find(GetBusScheduleById);
            if (busSchedule == null) 
            {
                return NotFound();
            }
            busSchedule.BusScheduleId = updateBusScheduleDto.BusScheduleId;
            busSchedule.DepartureTime = updateBusScheduleDto.DepartureTime;
            busSchedule.ArrivalTime = updateBusScheduleDto.ArrivalTime;
            dbContext.SaveChanges();
            return Ok(busSchedule);
        }

        [HttpDelete]
        [Route("{BusScheduleId:regex([[A-Za-z0-9!@#$%^&*()-_=+]])}")]
        public IActionResult DeleteBusSchedule(string BusScheduleId) 
        {
            var busSchedule = dbContext.BusSchedules.Find(BusScheduleId);
            if (busSchedule == null) 
            {
                return NotFound();
            }
            dbContext.BusSchedules.Remove(busSchedule); 
            dbContext.SaveChanges(); 
            return Ok(busSchedule);
        }

    }
}
