using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Repositories;
using HealthCare.API.Persistence.Contexts;
using System.Linq;

namespace HealthCare.API.Persistence.Repositories
{
    public class MedicationRepository : BaseRepository, IMedicationRepository
    {
        public MedicationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Medication>> ListAsync(int pageSize, int pageFirstIndex, string searchVal)
        {
            if (searchVal == null || (searchVal != null) && (searchVal.Trim().Equals("") || searchVal.Equals("null")))
            {
                if (pageSize != 0)
                {
                    return await _context.Medications.Skip((pageFirstIndex) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(true);
                }
                else
                {
                    return await _context.Medications.ToListAsync().ConfigureAwait(true);
                }
            }
            else
            {
                return await _context.Medications.Where(p => p.Name.ToLower().Contains(searchVal.ToLower())).Take(pageSize).ToListAsync();
            }
        }

        public async Task<Medication> FindByIdAsync(int id)
        {
            return await _context.Medications.FindAsync((short)id);
        }


        public int CountMedications(string searchVal)
        {
            if (searchVal == null)
            {
                searchVal = "";
            }
            return _context.Medications.Where(p => p.Name.ToLower().Contains(searchVal.ToLower())).Count();
        }


        public async Task AddAsync(Medication medication)
        {
            await _context.Medications.AddAsync(medication);
        }

        public void Update(Medication medication)
        {
            _context.Medications.Update(medication);
        }

        public void Remove(Medication medication)
        {
            _context.Medications.Remove(medication);
        }
    }
}