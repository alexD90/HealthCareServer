using HealthCare.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Repositories
{
    public interface IPractitionerRepository
    {
        Task<IEnumerable<Practitioner>> ListAsync(int pageSize, int pageFirstIndex, string searchVal);
        Task AddAsync(Practitioner practitioner);
        Task<Practitioner> FindByIdAsync(int id);
        void Update(Practitioner practitioner);
        void Remove(Practitioner practitioner);
        int CountPractitioners(string search);

    }
}
