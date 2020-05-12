using System.Collections.Generic;
using System.Threading.Tasks;
using HealthCare.API.Domain.Models;

namespace HealthCare.API.Domain.Repositories
{
    public interface IMedicationRepository
    {
        Task<IEnumerable<Medication>> ListAsync(int pageSize, int pageFirstIndex, string searchVal);
        Task AddAsync(Medication medication);
        Task<Medication> FindByIdAsync(int id);
        void Update(Medication medication);
        void Remove(Medication medication);
        int CountMedications(string searchVal);

    }

}