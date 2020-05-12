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
        public class PatientsController : Controller
        {
            private readonly IPatientService _patientService;
            private readonly IMapper _mapper;

            public PatientsController(IPatientService patientService, IMapper mapper)
            {
                _patientService = patientService;
                _mapper = mapper;
            }

        [Route("/api/[controller]/count")]
        [HttpGet]
        public int CountPatients([FromQuery]string searchVal)
        {
            return _patientService.CountPatients(searchVal);
        }


        [HttpGet]
            public async Task<IEnumerable<PatientResource>> GetAllAsync([FromQuery]int pageSize, [FromQuery]int pageFirstIndex, [FromQuery]string searchVal)
        {
                var patients = await _patientService.ListAsync(pageSize, pageFirstIndex, searchVal);
                var resources = _mapper.Map<IEnumerable<Patient>, IEnumerable<PatientResource>>(patients);
                return resources;
            }


            [HttpPost]
            public async Task<IActionResult> PostAsync([FromBody] SavePatientResource resource)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorMessages());

                var patient = _mapper.Map<SavePatientResource, Patient>(resource);
                var result = await _patientService.SaveAsync(patient);

                if (!result.Success)
                    return BadRequest(result.Message);

                var patientResource = _mapper.Map<Patient, PatientResource>(result.Patient);
                return Ok(patientResource);
            }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePatientResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var patient = _mapper.Map<SavePatientResource, Patient>(resource);
            var result = await _patientService.UpdateAsync(id, patient);

            if (!result.Success)
                return BadRequest(result.Message);

            var patientResource = _mapper.Map<Patient, PatientResource>(result.Patient);
            return Ok(patientResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _patientService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var patientResource = _mapper.Map<Patient, PatientResource>(result.Patient);
            return Ok(patientResource);
        }
    }
}
