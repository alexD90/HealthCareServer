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
        public class AppointmentsController : Controller
        {
            private readonly IAppointmentService _appointmentService;
            private readonly IMedicalRecordService _medicalRecordService;
            private readonly IMapper _mapper;

        public AppointmentsController(IAppointmentService appointmentService, IMedicalRecordService medicalRecordService, IMapper mapper)
            {
                _appointmentService = appointmentService;
            _medicalRecordService = medicalRecordService;
                _mapper = mapper;
            }

        [Route("/api/[controller]/count")]
        [HttpGet]
        public int CountAppointments([FromQuery]string searchVal)
        {
            return _appointmentService.CountAppointments(searchVal);
        }

        [HttpGet]
            public async Task<IEnumerable<AppointmentResource>> GetAllAsync([FromQuery]int pageSize, [FromQuery]int pageFirstIndex, [FromQuery]string searchVal)
        {
                var appointments = await _appointmentService.ListAsync(pageSize, pageFirstIndex, searchVal);
                var resources = _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentResource>>(appointments);
                return resources;
            }

       // [HttpGet]
        public async Task<IActionResult> FindById(int id)
        {
            var appointment = await _appointmentService.FindById(id).ConfigureAwait(false);
            return Ok(appointment);
        }

        [HttpPost]
            public async Task<IActionResult> PostAsync([FromBody] SaveAppointmentResource resource)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorMessages());

            //if appointment is created first time for a patient, create his medical record

            MedicalRecord medicalRecordForPatient = _medicalRecordService.GetByPatient(resource.PatientId);
            if (medicalRecordForPatient == null) {
                SaveMedicalRecordResource resource1 = new SaveMedicalRecordResource();
                resource1.Identifer = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "_" + resource.PatientId.ToString();
                resource1.PatientId = resource.PatientId;
                resource1.Established = DateTime.Now;
                var medicalRecord = _mapper.Map<SaveMedicalRecordResource, MedicalRecord>(resource1);
                await _medicalRecordService.SaveAsync(medicalRecord).ConfigureAwait(false);
            }
           
                   var appointment = _mapper.Map<SaveAppointmentResource, Appointment>(resource);
                var result = await _appointmentService.SaveAsync(appointment).ConfigureAwait(false);

                if (!result.Success)
                    return BadRequest(result.Message);

                var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Appointment);
                return Ok(appointmentResource);
            }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAppointmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var appointment = _mapper.Map<SaveAppointmentResource, Appointment>(resource);
            var result = await _appointmentService.UpdateAsync(id, appointment);

            if (!result.Success)
                return BadRequest(result.Message);

            var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Appointment);
            return Ok(appointmentResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _appointmentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Appointment);
            return Ok(appointmentResource);
        }
    }
}
