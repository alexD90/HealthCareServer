
using AutoMapper;
using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Services;
using HealthCare.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthCare.API.Extensions;
using System;

namespace HealthCare.API.Controllers
{
    [Route("/api/[controller]")]
    public class MedicationsController : Controller
    {
        private readonly IMedicationService _medicationsService;
        private readonly IMapper _mapper;


        public MedicationsController(IMedicationService medicationsService, IMapper mapper)
        {
            _medicationsService = medicationsService;
            _mapper = mapper;
        }

        [Route("/api/[controller]/count")]
        [HttpGet]
        public int CountMedications([FromQuery]string searchVal)
        {
            return _medicationsService.CountMedications(searchVal);
        }

        [HttpGet]
        public async Task<IEnumerable<MedicationResource>> GetAllAsync([FromQuery]int pageSize, [FromQuery]int pageFirstIndex, [FromQuery]string searchVal)
        {
            var diagnoses = await _medicationsService.ListAsync(pageSize, pageFirstIndex, searchVal);
            var resources = _mapper.Map<IEnumerable<Medication>, IEnumerable<MedicationResource>>(diagnoses);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveMedicationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var medication = _mapper.Map<SaveMedicationResource, Medication>(resource);
            var result = await _medicationsService.SaveAsync(medication);

            if (!result.Success)
                return BadRequest(result.Message);

            var medicationResource = _mapper.Map<Medication, MedicationResource>(result.Medication);
            return Ok(medicationResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMedicationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var diagnosis = _mapper.Map<SaveMedicationResource, Medication>(resource);
            var result = await _medicationsService.UpdateAsync(id, diagnosis);

            if (!result.Success)
                return BadRequest(result.Message);

            var medicationResource = _mapper.Map<Medication, MedicationResource>(result.Medication);
            return Ok(medicationResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _medicationsService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var medicationResource = _mapper.Map<Medication, MedicationResource>(result.Medication);
            return Ok(medicationResource);
        }
    }
}