using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Services
{
    public interface IMedicalRecordItemService
    {
        Task<IEnumerable<MedicalRecordItem>> ListAsync(int pageSize, int pageFirstIndex, string searchVal);
        Task<IEnumerable<MedicalRecordItem>> FindByRecordIdAsync(int id);
        Task<MedicalRecordItemResponse> SaveAsync(MedicalRecordItem medicalRecordItem);
        Task<MedicalRecordItemResponse> UpdateAsync(int id, MedicalRecordItem medicalRecordItem);
        Task<MedicalRecordItemResponse> DeleteAsync(int id);
        int CountMedicalRecordItems(string searchVal);

    }
}
