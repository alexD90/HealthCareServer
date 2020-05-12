using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Repositories;
using HealthCare.API.Persistence.Contexts;
using System.Linq;

namespace HealthCare.API.Persistence.Repositories
{
    public class LocationRepository : BaseRepository, ILocationRepository
    {
        public LocationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Location>> ListAsync(int pageSize, int pageFirstIndex, string searchVal)
        {
            if (searchVal == null || (searchVal != null) && (searchVal.Trim().Equals("") || searchVal.Equals("null")))
            {
                if (pageSize != 0)
                {
                    return await _context.Locations.Skip((pageFirstIndex) * pageSize).Take(pageSize).ToListAsync();
                }
                else
                {
                    return await _context.Locations.ToListAsync();
                }
            }
            else
            {
                return await _context.Locations.Where(p => p.Name.ToLower().Contains(searchVal.ToLower())).Take(pageSize).ToListAsync();
            }
        }

        public int CountLocations(string searchVal)
        {
            if (searchVal == null)
            {
                searchVal = "";
            }
            return _context.Locations.Where(p => p.Name.ToLower().Contains(searchVal.ToLower())).Count();
        }


        public async Task AddAsync(Location Location)
        {
            await _context.Locations.AddAsync(Location);
        }

        public async Task<Location> FindByIdAsync(int id)
        {
            return await _context.Locations.FindAsync(id);
        }

        public void Update(Location Location)
        {
            _context.Locations.Update(Location);
        }

        public void Remove(Location Location)
        {
            _context.Locations.Remove(Location);
        }
    }
}