using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Repositories;
using HealthCare.API.Persistence.Contexts;
 using System.Linq;

namespace HealthCare.API.Persistence.Repositories
{
    public class PractitionerRepository : BaseRepository, IPractitionerRepository
    {
        public PractitionerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Practitioner>> ListAsync(int pageSize, int pageFirstIndex, string searchVal)
        {

            if (searchVal == null || (searchVal != null) && (searchVal.Trim().Equals("") || searchVal.Equals("null")))
            {
                if (pageSize != 0)
                {
                    return await _context.Practitioners.Include(p => p.Patients).Skip((pageFirstIndex) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(true);
                }
                else
                {
                    return await _context.Practitioners.ToListAsync().ConfigureAwait(true);
                }
            }
            else
            {
                return await _context.Practitioners.Include(p => p.Patients).Where(p => p.FirstName.ToLower().Contains(searchVal.ToLower())
                || p.LastName.ToLower().Contains(searchVal.ToLower()) || p.Title.ToLower().Contains(searchVal.ToLower())).Take(pageSize).ToListAsync().ConfigureAwait(true);
            }
        }

        public int CountPractitioners(string searchVal)
        {
            if (searchVal == null)
            {
                searchVal = "";
            }
            return _context.Practitioners.Where(p => p.FirstName.ToLower().Contains(searchVal.ToLower())
                || p.LastName.ToLower().Contains(searchVal.ToLower()) || p.Title.ToLower().Contains(searchVal.ToLower())).Count();
        }


        public async Task AddAsync(Practitioner practitioner)
        {
            await _context.Practitioners.AddAsync(practitioner);
        }

        public async Task<Practitioner> FindByIdAsync(int id)
        {
            return await _context.Practitioners.FindAsync(id);
        }

        public void Update(Practitioner practitioner)
        {
            _context.Practitioners.Update(practitioner);
        }

        public void Remove(Practitioner practitioner)
        {
            _context.Practitioners.Remove(practitioner);
        }
    }
}