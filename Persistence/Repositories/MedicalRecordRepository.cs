using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Repositories;
using HealthCare.API.Persistence.Contexts;
 using System.Linq;

namespace HealthCare.API.Persistence.Repositories
{
    public class MedicalRecordRepository : BaseRepository, IMedicalRecordRepository
    {
        public MedicalRecordRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MedicalRecord>> ListAsync(int pageSize, int pageFirstIndex, string searchVal)
        {
            if (searchVal == null || (searchVal != null) && (searchVal.Trim().Equals("") || searchVal.Equals("null")))
            {
                return await _context.MedicalRecords.Include(p => p.Patient).Include(p => p.Items).Skip((pageFirstIndex) * pageSize).Take(pageSize).ToListAsync();
            }
            else
            {
                return await _context.MedicalRecords.Include(p => p.Patient).Where(p => p.Identifier.ToLower().Contains(searchVal.ToLower()) ||
                p.Patient.FirstName.ToLower().Contains(searchVal.ToLower() ) || 
                p.Patient.LastName.ToLower().Contains(searchVal.ToLower()) || p.PatientId.ToString().Equals(searchVal)
                ).Take(pageSize).ToListAsync();
            }

        }

        public int CountMedicalRecords(string searchVal)
        {
            if (searchVal == null)
            {
                searchVal = "";
            }
            return _context.MedicalRecords.Where(p => p.Identifier.ToLower().Contains(searchVal.ToLower()) ||
                p.Patient.FirstName.ToLower().Contains(searchVal.ToLower()) ||
                p.Patient.LastName.ToLower().Contains(searchVal.ToLower()) || p.PatientId.ToString().Equals(searchVal)
                ).Count();
        }


        public async Task<MedicalRecord> FindByPatientIdAsync(int id)
        {
            return  _context.MedicalRecords.Where(p => p.PatientId == id).Include(p => p.Items).Include(p => p.Patient)
                .First();
        }

        public MedicalRecord GetByPatient(int id)
        {
            return _context.MedicalRecords.FirstOrDefault(a => a.PatientId == id);
         }

        public async Task AddAsync(MedicalRecord medicalRecord)
        {
            await _context.MedicalRecords.AddAsync(medicalRecord);
        }

        public async Task<MedicalRecord> FindByIdAsync(int id)
        {
            return await _context.MedicalRecords.FindAsync(id);
        }

        public void Update(MedicalRecord medicalRecord)
        {
            _context.MedicalRecords.Update(medicalRecord);
        }

        public void Remove(MedicalRecord medicalRecord)
        {
            _context.MedicalRecords.Remove(medicalRecord);
        }
    }
}