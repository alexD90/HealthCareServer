using HealthCare.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Repositories
{
    public interface IMedicalRecordItemRepository
    {
        Task<IEnumerable<MedicalRecordItem>> ListAsync(int pageSize, int pageFirstIndex, string searchVal);
        Task AddAsync(MedicalRecordItem medicalRecordItem);
        Task<MedicalRecordItem> FindByIdAsync(int id);
        Task<IEnumerable<MedicalRecordItem>> FindByRecordIdAsync(int id);
        void Update(MedicalRecordItem medicalRecordItem);
        void Remove(MedicalRecordItem medicalRecordItem);
        int CountMedicalRecordItems(string searchVal);

    }
}
