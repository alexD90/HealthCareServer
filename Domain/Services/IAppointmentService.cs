using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> ListAsync(int pageSize, int pageFirstIndex, string searchVal);
        Task<AppointmentResponse> SaveAsync(Appointment appointment);
        Task<AppointmentResponse> UpdateAsync(int id, Appointment appointment);
        Task<AppointmentResponse> DeleteAsync(int id);
        int CountAppointments(string searchVal);

        Task<Appointment> FindById(int id);

    }
}
