using HealthCare.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> ListAsync(int pageSize, int pageFirstIndex, string searchVal);
        Task AddAsync(Patient patient);
        Task<Patient> FindByIdAsync(int id);
        void Update(Patient patient);
        void Remove(Patient patient);
        int CountPatients(string searchVal);

    }
}
