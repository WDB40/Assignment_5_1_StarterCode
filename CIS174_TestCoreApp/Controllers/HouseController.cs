using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        public IEnumerable<HouseViewModel> Houses = new List<HouseViewModel>() {
            new HouseViewModel(1, 4, 1854, new DateTime(1973, 5, 28), "Carpet"),
            new HouseViewModel(2, 3, 1675, new DateTime(2015, 10, 17), "Hardwood")
        };

        [HttpGet]
        public IActionResult AllHouses()
        {
            return Ok(Houses);
        }

        [HttpGet("{id}")]
        public IActionResult GetHouse(int id)
        {
            foreach(HouseViewModel house in Houses)
            {
                if(house.Id == id)
                {
                    return Ok(house);
                }
            }

            return NotFound();
        }
        [HttpPost("create")]
        public HouseViewModel AddHouse([FromBody] HouseViewModel house)
        {
            List<HouseViewModel> houseList = Houses.ToList();
            houseList.Add(house);
            Houses = houseList;

            Response.StatusCode = StatusCodes.Status201Created;

            return house;
        }
    }
}