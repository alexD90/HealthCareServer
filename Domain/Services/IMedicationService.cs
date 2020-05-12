using System.Collections.Generic;
using System.Threading.Tasks;
using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Services.Communication;

namespace HealthCare.API.Domain.Services
{
    public interface IMedicationService
    {
        Task<IEnumerable<Medication>> ListAsync(int pageSize, int pageFirstIndex, string searchVal);
        Task<MedicationResponse> SaveAsync(Medication medication);
        Task<MedicationResponse> UpdateAsync(int id, Medication medication);
        Task<MedicationResponse> DeleteAsync(int id);
        int CountMedications(string searchVal);

    }
}