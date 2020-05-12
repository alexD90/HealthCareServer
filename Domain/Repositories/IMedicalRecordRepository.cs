using HealthCare.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Repositories
{
    public interface IMedicalRecordRepository
    {
        Task<IEnumerable<MedicalRecord>> ListAsync(int pageSize, int pageFirstIndex, string searchVal);
        Task AddAsync(MedicalRecord medicalRecord);
        Task<MedicalRecord> FindByPatientIdAsync(int id);
        Task<MedicalRecord> FindByIdAsync(int id);
        int CountMedicalRecords(string searchVal);

        MedicalRecord GetByPatient(int patientId);
        void Update(MedicalRecord medicalRecord);
        void Remove(MedicalRecord medicalRecord);
    }
}
