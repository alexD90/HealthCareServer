using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Services
{
    public interface IMedicalRecordService
    {
        Task<IEnumerable<MedicalRecord>> ListAsync(int pageSize, int pageFirstIndex, string searchVal);
        Task<MedicalRecordResponse> SaveAsync(MedicalRecord medicalRecord);
        Task<MedicalRecord> FindByPatientIdAsync(int id);
        int CountMedicalRecords(string searchVal);

        MedicalRecord GetByPatient(int patientId);

        Task<MedicalRecordResponse> UpdateAsync(int id, MedicalRecord medicalRecord);
        Task<MedicalRecordResponse> DeleteAsync(int id);

    }
}
