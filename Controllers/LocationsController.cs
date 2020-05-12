
using AutoMapper;
using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Services;
using HealthCare.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthCare.API.Extensions;


namespace HealthCare.API.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors("MyPolicy")]
    [Route("/api/[controller]")]
    public class LocationsController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;


        public LocationsController(ILocationService LocationService, IMapper mapper)
        {
            _locationService = LocationService;
            _mapper = mapper;
        }

        [Route("/api/[controller]/count")]
        [HttpGet]
        public int CountLocations([FromQuery]string searchVal)
        {
            return _locationService.CountLocations(searchVal);
        }

        [HttpGet]
        public async Task<IEnumerable<LocationResource>> GetAllAsync([FromQuery]int pageSize, [FromQuery]int pageFirstIndex, [FromQuery]string searchVal)
        {
            var locations = await _locationService.ListAsync(pageSize, pageFirstIndex, searchVal);
            var resources = _mapper.Map<IEnumerable<Location>, IEnumerable<LocationResource>>(locations);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveLocationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var Location = _mapper.Map<SaveLocationResource, Location>(resource);
            var result = await _locationService.SaveAsync(Location);

            if (!result.Success)
                return BadRequest(result.Message);

            var LocationResource = _mapper.Map<Location, LocationResource>(result.Location);
            return Ok(LocationResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveLocationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var Location = _mapper.Map<SaveLocationResource, Location>(resource);
            var result = await _locationService.UpdateAsync(id, Location);

            if (!result.Success)
                return BadRequest(result.Message);

            var LocationResource = _mapper.Map<Location, LocationResource>(result.Location);
            return Ok(LocationResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _locationService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var LocationResource = _mapper.Map<Location, LocationResource>(result.Location);
            return Ok(LocationResource);
        }
    }
}