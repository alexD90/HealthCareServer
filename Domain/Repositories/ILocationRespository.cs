using System.Collections.Generic;
using System.Threading.Tasks;
using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Services.Communication;

namespace HealthCare.API.Domain.Repositories
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> ListAsync(int pageSize, int pageFirstIndex, string searchVal);
        Task AddAsync(Location location);
        Task<Location> FindByIdAsync(int id);
        void Update(Location location);
        void Remove(Location location);
        int CountLocations(string searchVal);

    }
}