using HealthCare.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Repositories
{
    public interface IDiagnosisRepository
    {
        Task<IEnumerable<Diagnosis>> ListAsync(int pageSize, int pageFirstIndex, string searchVal);
        Task AddAsync(Diagnosis diagnosis);
        Task<Diagnosis> FindByIdAsync(int id);
        void Update(Diagnosis diagnosis);
        void Remove(Diagnosis diagnosis);
        int CountDiagnoses(string searchVal);

    }
}
