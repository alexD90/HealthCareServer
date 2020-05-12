using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Services
{
    public interface IDiagnosisService
    {
        Task<IEnumerable<Diagnosis>> ListAsync(int pageSize, int pageFirstIndex, string searchVal);
        Task<DiagnosisResponse> SaveAsync(Diagnosis diagnosis);
        Task<DiagnosisResponse> UpdateAsync(int id, Diagnosis diagnosis);
        Task<DiagnosisResponse> DeleteAsync(int id);
        int CountDiagnoses(string searchVal);

    }
}
