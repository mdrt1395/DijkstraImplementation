using DijkstraImplementation.Data;
using DijkstraImplementation.Models.DTOs.BusInfoDTOs;
using DijkstraImplementation.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DijkstraImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusInfoController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public BusInfoController(AppDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllBusInfos()
        {
            var allBusInfos = dbContext.BusInfos.ToList();
            return Ok(allBusInfos);
        }

        [HttpGet]
        [Route("{BusPlates:regex([[A-Za-z0-9!@#$%^&*()-_=+]])}")]
        public IActionResult getBusByBusPlates(string BusPlates) 
        {
            var bus = dbContext.BusInfos.Find(BusPlates);
            if (bus is null) 
            {
                return NotFound();
            }
            return Ok(bus);
         
        }

        [HttpPost]
        public IActionResult AddBusInfo(AddBusInfoDto addBusInfoDto)
        {
            var busEntity = new BusInfo()
            {
                BusInfoId = addBusInfoDto.BusInfoId,
                BusPlates = addBusInfoDto.BusPlates,
                NumberOfSeats = addBusInfoDto.NumberOfSeats
            };
            dbContext.BusInfos.Add(busEntity);
            dbContext.SaveChanges();
            return Ok(busEntity);
        }

        //[HttpPut]
        //[Route("{BusPlates:regex([[A-Za-z0-9!@#$%^&*()-_=+]])}")]
        //public IActionResult UpdateBusInfo(string BusPlates, UpdateBusInfoDto updateBusInfoDto) 
        //{
        //    var bus = dbContext.BusInfos.Find(BusPlates);
        //    if ( bus is null)
        //    {
        //        return NotFound();
        //    }
        //    bus.IsAvailable = updateBusInfoDto.IsAvailable;
        //    dbContext.SaveChanges();
        //    return Ok(bus);
        //}

        [HttpDelete]
        [Route("{BusPlates:regex([[A-Za-z0-9!@#$%^&*()-_=+]])}")]
        public IActionResult DeleteBusInfo(string BusPlates)
        {
            var bus = dbContext.BusInfos.Find(BusPlates);
            if( bus is null )
            {
                return NotFound();
            }
            dbContext.BusInfos.Remove(bus);
            dbContext.SaveChanges();
            return Ok(bus);
        }



    }
}
