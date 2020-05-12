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
    public class MedicalRecordItemController : Controller
    {
        private readonly IMedicalRecordItemService _medicalRecordItemService;
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public MedicalRecordItemController(IMedicalRecordItemService medicalRecordItemService, IAppointmentService appointmentService, IMapper mapper)
        {
            _medicalRecordItemService = medicalRecordItemService;
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        [Route("/api/[controller]/count")]
        [HttpGet]
        public int CountMedicalRecordItems([FromQuery]string searchVal)
        {
            return _medicalRecordItemService.CountMedicalRecordItems(searchVal);
        }

        [HttpGet]
        public async Task<IEnumerable<MedicalRecordItemResource>> GetAllAsync([FromQuery]int pageSize, [FromQuery]int pageFirstIndex, [FromQuery]string searchVal)
        {
            var medicalRecordItem = await _medicalRecordItemService.ListAsync(pageSize, pageFirstIndex, searchVal);
            var resources = _mapper.Map<IEnumerable<MedicalRecordItem>, IEnumerable<MedicalRecordItemResource>>(medicalRecordItem);
            return resources;
        }


        [Route("/api/[controller]/findbyrecord/{id}")]
        [HttpGet]
        public async Task<IEnumerable<MedicalRecordItemResource>> FindByRecordIdAsync(int id)
        {
            var medicalRecordItem = await _medicalRecordItemService.FindByRecordIdAsync(id).ConfigureAwait(true);
            var resources = _mapper.Map<IEnumerable<MedicalRecordItem>, IEnumerable<MedicalRecordItemResource>>(medicalRecordItem);
            return resources;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveMedicalRecordItemResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var medicalRecordItem = _mapper.Map<SaveMedicalRecordItemResource, MedicalRecordItem>(resource);

            var result = await _medicalRecordItemService.SaveAsync(medicalRecordItem).ConfigureAwait(false);

            Appointment appointment = await _appointmentService.FindById(resource.AppointmentId).ConfigureAwait(true);
            if (appointment != null)
            {
                appointment.Finished = true;
                await _appointmentService.UpdateAsync(appointment.Id, appointment).ConfigureAwait(true);
            }

            if (!result.Success)
                return BadRequest(result.Message);

            var medicalRecordItemResource = _mapper.Map<MedicalRecordItem, MedicalRecordItemResource>(result.MedicalRecordItem);
            return Ok(medicalRecordItemResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMedicalRecordItemResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var medicalRecordItem = _mapper.Map<SaveMedicalRecordItemResource, MedicalRecordItem>(resource);
            var result = await _medicalRecordItemService.UpdateAsync(id, medicalRecordItem);

            if (!result.Success)
                return BadRequest(result.Message);

            var medicalRecordItemResource = _mapper.Map<MedicalRecordItem, MedicalRecordItemResource>(result.MedicalRecordItem);
            return Ok(medicalRecordItemResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _medicalRecordItemService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var medicalRecordItemResource = _mapper.Map<MedicalRecordItem, MedicalRecordItemResource>(result.MedicalRecordItem);
            return Ok(medicalRecordItemResource);
        }
    }
}
