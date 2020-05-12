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
    public class MedicalRecordsController : Controller
    {
        private readonly IMedicalRecordService _medicalRecordService;
        private readonly IMapper _mapper;

        public MedicalRecordsController(IMedicalRecordService medicalRecordService, IMapper mapper)
        {
            _medicalRecordService = medicalRecordService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MedicalRecordResource>> GetAllAsync([FromQuery]int pageSize, [FromQuery]int pageFirstIndex, [FromQuery]string searchVal)
        {
            var medicalRecords = await _medicalRecordService.ListAsync(pageSize, pageFirstIndex, searchVal);
            var resources = _mapper.Map<IEnumerable<MedicalRecord>, IEnumerable<MedicalRecordResource>>(medicalRecords);
            return resources;
        }

        [Route("/api/[controller]/count")]
        [HttpGet]
        public int CountMedicalRecords([FromQuery]string searchVal)
        {
            return _medicalRecordService.CountMedicalRecords(searchVal);
        }

        [Route("/api/[controller]/findbypatient/{id}")]
        [HttpGet]
        public async Task<MedicalRecordResource> FindByPatientIdAsync(int id)
        {
            var medicalRecord = await _medicalRecordService.FindByPatientIdAsync(id).ConfigureAwait(true);
            var resources = _mapper.Map<MedicalRecord, MedicalRecordResource>(medicalRecord);
            return resources;
        }
        /*        [HttpGet("{id}")]
                public async Task<MedicalRecordResource> GetByPatient(int id)
                {
                    var medicalRecord = await _medicalRecordService.GetByPatient(id);
                    var resource = _mapper.Map<MedicalRecord, MedicalRecordResource>(medicalRecord);
                    return resource;
                }*/

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveMedicalRecordResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var medicalRecord = _mapper.Map<SaveMedicalRecordResource, MedicalRecord>(resource);
            var result = await _medicalRecordService.SaveAsync(medicalRecord);

            if (!result.Success)
                return BadRequest(result.Message);

            var medicalRecordResource = _mapper.Map<MedicalRecord, MedicalRecordResource>(result.MedicalRecord);
            return Ok(medicalRecordResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMedicalRecordResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var medicalRecord = _mapper.Map<SaveMedicalRecordResource, MedicalRecord>(resource);
            var result = await _medicalRecordService.UpdateAsync(id, medicalRecord);

            if (!result.Success)
                return BadRequest(result.Message);

            var medicalRecordResource = _mapper.Map<MedicalRecord, MedicalRecordResource>(result.MedicalRecord);
            return Ok(medicalRecordResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _medicalRecordService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var medicalRecordResource = _mapper.Map<MedicalRecord, MedicalRecordResource>(result.MedicalRecord);
            return Ok(medicalRecordResource);
        }
    }
}
