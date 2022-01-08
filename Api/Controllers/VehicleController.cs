using Api.DTO;
using AutoMapper;
using Business.Abstract;
using Data.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;
        public VehicleController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }
       [HttpGet]
       public ActionResult GetAll()
        {
            var result = _vehicleService.GetAll();
            return Ok(result);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _vehicleService.Delete(id);    
        }
        [HttpPost]
        public void Insert(VehicleDTO vehicle)
        {
            var mapped = _mapper.Map<Vehicle>(vehicle);
              _vehicleService.Insert(mapped);
        }

        [HttpPut]
        public void Update(Vehicle vehicle)
        {
            _vehicleService.Update(vehicle);
        }

    }
}
