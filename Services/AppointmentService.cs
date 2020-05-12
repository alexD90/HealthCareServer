
using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Repositories;
using HealthCare.API.Domain.Services;
using HealthCare.API.Domain.Services.Communication;
using HealthCare.API.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentService(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork)
        {
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
        }

        public int CountAppointments(string searchVal)
        {
            return _appointmentRepository.CountAppointments(searchVal);
        }

        public async Task<IEnumerable<Appointment>> ListAsync(int pageSize, int pageFirstIndex, string search)
        {
            return await _appointmentRepository.ListAsync(pageSize, pageFirstIndex, search);
        }

        public async Task<Appointment> FindById(int id)
        {
            Appointment x = await _appointmentRepository.FindByIdAsync(id);
            return x;
        }

        public async Task<AppointmentResponse> SaveAsync(Appointment appointment)
        {
            try
            {
                await _appointmentRepository.AddAsync(appointment);
                await _unitOfWork.CompleteAsync();
                return new AppointmentResponse(appointment);
            }
            catch (Exception ex)
            {
                return new AppointmentResponse($"An error occurred when saving the appointment: {ex.Message}");
            }
        }

        public async Task<AppointmentResponse> UpdateAsync(int id, Appointment appointment)
        {
            var existingAppointment = await _appointmentRepository.FindByIdAsync(id);

            if (existingAppointment == null)
                return new AppointmentResponse("appointment not found.");

            existingAppointment.StartTime = appointment.StartTime;
            existingAppointment.EndTime = appointment.EndTime;
            existingAppointment.Date = appointment.Date;
            //existingAppointment.PatientId = appointment.PatientId;
            //existingAppointment.PractitionerId = appointment.PractitionerId;
            existingAppointment.Canceled = appointment.Canceled;
            existingAppointment.Finished = appointment.Finished;
          //  existingAppointment.


            try
            {
                _appointmentRepository.Update(existingAppointment);
                await _unitOfWork.CompleteAsync();

                return new AppointmentResponse(existingAppointment);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new AppointmentResponse($"An error occurred when updating the appointment: {ex.Message}");
            }
        }

        public async Task<AppointmentResponse> DeleteAsync(int id)
        {
            var existingAppointment = await _appointmentRepository.FindByIdAsync(id);

            if (existingAppointment == null)
                return new AppointmentResponse("Appointment not found.");

            try
            {
                _appointmentRepository.Remove(existingAppointment);
                await _unitOfWork.CompleteAsync();

                return new AppointmentResponse(existingAppointment);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new AppointmentResponse($"An error occurred when deleting the appointment: {ex.Message}");
            }
        }

    }
}
