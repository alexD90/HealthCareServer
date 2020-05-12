using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> ListAsync(int pageSize, int pageFirstIndex, string searchVal);
        Task<PatientResponse> SaveAsync(Patient patient);
        Task<PatientResponse> UpdateAsync(int id, Patient patient);
        Task<PatientResponse> DeleteAsync(int id);
        int CountPatients(string searchVal);

    }
}
