using DijkstraImplementation.Data;
using DijkstraImplementation.Models.DTOs.BusInfoDTOs;
using DijkstraImplementation.Models.DTOs.RouteInfoDTOs;
using DijkstraImplementation.Models.DTOs.UserDTOs;
using DijkstraImplementation.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DijkstraImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteInfoController: ControllerBase
    {
        private readonly AppDbContext dbContext;

        public RouteInfoController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllRouteInfos()
        {
            var allRouteInfos = dbContext.Routes.ToList();
            return Ok(allRouteInfos);
        }

        [HttpGet]
        [Route("{RouteName:regex([[a-z]]{{2}})}")]
        public IActionResult GetRouteByRouteName(string RouteName)
        {
            var route = dbContext.Routes.Find(RouteName);
            if (route is null)
            {
                return NotFound();
            }
            return Ok(route);
        }

        [HttpPost]
        public IActionResult AddRouteInfo(AddRouteInfoDto addRouteInfoDto)
        {
            var routeEntity = new RouteInfo()
            {
                RouteName = addRouteInfoDto.RouteName,
                Origin = addRouteInfoDto.Origin,
                Destiny = addRouteInfoDto.Destiny,
                Distance = addRouteInfoDto.Distance,
            };
            dbContext.Routes.Add(routeEntity);
            dbContext.SaveChanges();
            return Ok(routeEntity);
        }

        [HttpPut]
        [Route("{RouteName:regex([[a-z]]{{2}})}")]
        public IActionResult UpdateRouteInfo(string RouteName, UpdateRouteInfoDto updateRouteInfoDto)
        {
            var route = dbContext.Routes.Find(RouteName);
            if (route is null)
            {
                return NotFound();
            }
            route.RouteName = updateRouteInfoDto.RouteName;
            route.Origin = updateRouteInfoDto.Origin;
            route.Destiny = updateRouteInfoDto.Destiny;
            route.Distance = updateRouteInfoDto.Distance;
            dbContext.SaveChanges();
            return Ok(route);
        }

        [HttpDelete]
        [Route("{RouteName:regex([[a-z]]{{2}})}")]
        public IActionResult DeleteRouteInfo(string RouteName)
        {
            var route = dbContext.Routes.Find(RouteName);
            if (route is null)
            {
                return NotFound();
            }
            dbContext.Routes.Remove(route);
            dbContext.SaveChanges();
            return Ok(route);
        }
    }
}
