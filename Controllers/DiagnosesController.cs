
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
    [Microsoft.AspNetCore.Cors.EnableCors("MyPolicy")]
    [Route("/api/[controller]")]
    public class DiagnosesController : Controller
    {
        private readonly IDiagnosisService _diagnosisService;
        private readonly IMapper _mapper;


        public DiagnosesController(IDiagnosisService diagnosisService, IMapper mapper)
        {
            _diagnosisService = diagnosisService;
            _mapper = mapper;
        }

        [Route("/api/[controller]/count")]
        [HttpGet]
        public int CountDiagnoses([FromQuery]string searchVal)
        {
            return _diagnosisService.CountDiagnoses(searchVal);
        }

        [HttpGet]
        public async Task<IEnumerable<DiagnosisResource>> GetAllAsync([FromQuery]int pageSize, [FromQuery]int pageFirstIndex, [FromQuery]string searchVal)
        {
            var diagnoses = await _diagnosisService.ListAsync(pageSize, pageFirstIndex, searchVal);
            var resources = _mapper.Map<IEnumerable<Diagnosis>, IEnumerable<DiagnosisResource>>(diagnoses);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDiagnosisResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var diagnosis = _mapper.Map<SaveDiagnosisResource, Diagnosis>(resource);
            var result = await _diagnosisService.SaveAsync(diagnosis);

            if (!result.Success)
                return BadRequest(result.Message);

            var diagnosisResource = _mapper.Map<Diagnosis, DiagnosisResource>(result.Diagnosis);
            return Ok(diagnosisResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDiagnosisResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var diagnosis = _mapper.Map<SaveDiagnosisResource, Diagnosis>(resource);
            var result = await _diagnosisService.UpdateAsync(id, diagnosis);

            if (!result.Success)
                return BadRequest(result.Message);

            var diagnosisResource = _mapper.Map<Diagnosis, DiagnosisResource>(result.Diagnosis);
            return Ok(diagnosisResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _diagnosisService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var diagnosisResource = _mapper.Map<Diagnosis, DiagnosisResource>(result.Diagnosis);
            return Ok(diagnosisResource);
        }
    }
}