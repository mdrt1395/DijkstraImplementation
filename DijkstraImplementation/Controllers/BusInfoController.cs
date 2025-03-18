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
        [Route("{BusPlates:regex([[a-z]]{{2}})}")]
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
                BusPlates = addBusInfoDto.BusPlates,
                NumberOfSeats = addBusInfoDto.NumberOfSeats,
                IsAvailable = addBusInfoDto.IsAvailable,
                BusCategoryId = new Guid()
            };
            dbContext.BusInfos.Add(busEntity);
            dbContext.SaveChanges();
            return Ok(busEntity);
        }

        [HttpPut]


    }
}
