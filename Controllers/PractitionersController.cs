using AutoMapper;
using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Services;
using HealthCare.API.Extensions;
using HealthCare.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Controllers
{
    [Route("/api/[controller]")]
    public class PractitionersController : Controller
    {
        private readonly IPractitionerService _practitionerService;
        private readonly IMapper _mapper;

        public PractitionersController(IPractitionerService practitionerService, IMapper mapper)
        {
            _practitionerService = practitionerService;
            _mapper = mapper;
        }

        [Route("/api/[controller]/count")]
        [HttpGet]
        public int CountPractitioners([FromQuery]string searchVal)
        {
            return _practitionerService.CountPractitioners(searchVal);
        }

        [HttpGet]
        public async Task<IEnumerable<PractitionerResource>> GetAllAsync([FromQuery]int pageSize, [FromQuery]int pageFirstIndex, [FromQuery]string searchVal)
        {
            var practitioners = await _practitionerService.ListAsync(pageSize, pageFirstIndex, searchVal);
            var resources = _mapper.Map<IEnumerable<Practitioner>, IEnumerable<PractitionerResource>>(practitioners);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePractitionerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var practitioner = _mapper.Map<SavePractitionerResource, Practitioner>(resource);
            var result = await _practitionerService.SaveAsync(practitioner);

            if (!result.Success)
                return BadRequest(result.Message);

            var practitionerResource = _mapper.Map<Practitioner, PractitionerResource>(result.Practitioner);
            return Ok(practitionerResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePractitionerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var practitioner = _mapper.Map<SavePractitionerResource, Practitioner>(resource);
            var result = await _practitionerService.UpdateAsync(id, practitioner);

            if (!result.Success)
                return BadRequest(result.Message);

            var practitionerResource = _mapper.Map<Practitioner, PractitionerResource>(result.Practitioner);
            return Ok(practitionerResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _practitionerService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var practitionerResource = _mapper.Map<Practitioner, PractitionerResource>(result.Practitioner);
            return Ok(practitionerResource);
        }
    }
}
