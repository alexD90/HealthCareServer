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
    public class PatientRepository : BaseRepository, IPatientRepository
    {
        public PatientRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Patient>> ListAsync(int pageSize, int pageFirstIndex, string searchVal)
        {
            if (searchVal == null || (searchVal != null) && (searchVal.Trim().Equals("") || searchVal.Equals("null")))
            {
                if (pageSize != 0) {
                    return await _context.Patients.Include(p => p.Practitioner).Skip((pageFirstIndex) * pageSize).Take(pageSize).ToListAsync();
                } else
                {
                    return await _context.Patients.ToListAsync();
                }
            }
            else
            {
                return await _context.Patients.Include(p => p.Practitioner).Where(p => p.FirstName.ToLower().Contains(searchVal.ToLower())
                || p.LastName.ToLower().Contains(searchVal.ToLower()) || p.PersonalNumber.ToLower().Contains(searchVal.ToLower())).Take(pageSize).ToListAsync();
            }
        }

        public async Task<Patient> FindByIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }


        public int CountPatients(string searchVal)
        {
            if (searchVal == null)
            {
                searchVal = "";
            }
            return _context.Patients.Where(p => p.FirstName.ToLower().Contains(searchVal.ToLower())
                || p.LastName.ToLower().Contains(searchVal.ToLower()) || p.PersonalNumber.ToLower().Contains(searchVal.ToLower())).Count();
        }


        public async Task AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
        }


        public void Update(Patient patient)
        {
            _context.Patients.Update(patient);
        }

        public void Remove(Patient patient)
        {
            _context.Patients.Remove(patient);
        }
    }
}
