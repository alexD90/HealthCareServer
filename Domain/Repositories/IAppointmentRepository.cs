using HealthCare.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> ListAsync(int pageSize, int pageFirstIndex, string searchVal);
        Task AddAsync(Appointment appointment);
        Task<Appointment> FindByIdAsync(int id);
        void Update(Appointment appointment);
        void Remove(Appointment appointment);
        int CountAppointments(string searchVal);

    }
}
