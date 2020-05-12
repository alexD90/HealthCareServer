using System.Collections.Generic;
using System.Threading.Tasks;
using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Services.Communication;

namespace HealthCare.API.Domain.Services
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> ListAsync(int pageSize, int pageFirstIndex, string searchVal);
        Task<LocationResponse> SaveAsync(Location location);
        Task<LocationResponse> UpdateAsync(int id, Location location);
        Task<LocationResponse> DeleteAsync(int id);
        int CountLocations(string searchVal);


    }
}