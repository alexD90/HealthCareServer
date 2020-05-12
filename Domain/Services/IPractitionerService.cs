using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Services
{
    public interface IPractitionerService
    {
        Task<IEnumerable<Practitioner>> ListAsync(int pageSize, int pageFirstIndex, string searchVal);
        Task<PractitionerResponse> SaveAsync(Practitioner practitioner);
        Task<PractitionerResponse> UpdateAsync(int id, Practitioner practitioner);
        Task<PractitionerResponse> DeleteAsync(int id);
        int CountPractitioners(string search);

    }
}
