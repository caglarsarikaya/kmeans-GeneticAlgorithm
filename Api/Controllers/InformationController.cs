using Business.Abstract;
using Data.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : ControllerBase
    {
        private readonly IInformationService _informationService;

        public InformationController(IInformationService informationService)
        {
            _informationService = informationService;
        }

        [HttpGet("GetVehicleRoute")]
        public ActionResult GetVehicleRoute(int Id)
        {
            var result = _informationService.GetVehicleRoute(Id);   
            return Ok(result);  
        }

        [HttpGet("CreateClusters/{clusterCount}")]
        public ActionResult CreateClusters(int clusterCount)
        {
            var result = _informationService.CreateClusters(clusterCount);
            return Ok(result);
        }


    }
}
