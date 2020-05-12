using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Repositories;
using HealthCare.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Persistence.Repositories
{
    public class AppointmentRepository : BaseRepository, IAppointmentRepository
    {
        public AppointmentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Appointment>> ListAsync(int pageSize, int pageFirstIndex, string searchVal)
        {
            if (searchVal == null || (searchVal != null) && (searchVal.Trim().Equals("") || searchVal.Equals("null")))
            {
                return await _context.Appointments.Include(p => p.Patient).Include(p => p.Practitioner).Include(p => p.Location)
                   .Where(p => p.Canceled.Equals(false) && p.Finished.Equals(false)).Skip((pageFirstIndex) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false);
            }
            else {
                return await _context.Appointments.Include(p => p.Patient).Include(p => p.Practitioner).Include(p => p.Location)
                    .Where(p => p.StartTime.Equals(searchVal.ToLower()) || p.Patient.FirstName.Equals(searchVal.ToLower()) || p.Patient.LastName.Equals(searchVal.ToLower())
                    || p.Practitioner.FirstName.Equals(searchVal.ToLower()) || p.Practitioner.LastName.Equals(searchVal.ToLower())
                     || p.Location.Name.Equals(searchVal.ToLower())
                   || p.EndTime.Equals(searchVal.ToLower())).Take(pageSize).ToListAsync().ConfigureAwait(false);
            }
        }

        public int CountAppointments(string searchVal)
        {
            if (searchVal == null)
            {
                searchVal = "";
            }
            return _context.Appointments.Where(p => p.Canceled.Equals(false) && p.Finished.Equals(false)).Count();
        }


        public async Task AddAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
        }

        public async Task<Appointment> FindByIdAsync(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public void Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
        }

        public void Remove(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
        }
    }
}
