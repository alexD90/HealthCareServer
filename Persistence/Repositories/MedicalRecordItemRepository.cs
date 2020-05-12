using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Repositories;
using HealthCare.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Persistence.Repositories
{
    public class MedicalRecordItemRepository : BaseRepository, IMedicalRecordItemRepository
    {
        public MedicalRecordItemRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MedicalRecordItem>> ListAsync(int pageSize, int pageFirstIndex, string searchVal)
        {
            if (searchVal == null || (searchVal != null) && (searchVal.Trim().Equals("") || searchVal.Equals("null")))
            {
                return await _context.MedicalRecordItems.Include(p => p.MedicalRecord).Include(p => p.Medication).Include(p=>p.Diagnosis).Include(p=>p.Appointment).Skip((pageFirstIndex) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(true);
            }
            else
            {
                return await _context.MedicalRecordItems.Include(p => p.MedicalRecord).Include(p => p.Medication).Include(p => p.Diagnosis).Include(p => p.Appointment)
                    .Where(p => p.MedicalRecord.PatientId.ToString().Equals(searchVal) || 
                p.MedicalRecordId.ToString().Equals(searchVal)).Take(pageSize).ToListAsync().ConfigureAwait(true);
            }
        }

        public int CountMedicalRecordItems(string searchVal)
        {
            if (searchVal == null)
            {
                searchVal = "";
            }
            return _context.MedicalRecordItems.Where(p => p.MedicalRecord.PatientId.ToString().Equals(searchVal) ||
                p.MedicalRecordId.ToString().Equals(searchVal)).Count();
        }


        public async Task AddAsync(MedicalRecordItem medicalRecordItem)
        {
            await _context.MedicalRecordItems.AddAsync(medicalRecordItem);
        }

        public async Task<MedicalRecordItem> FindByIdAsync(int id)
        {
            return await _context.MedicalRecordItems.FindAsync(id);
        }

        public async Task<IEnumerable<MedicalRecordItem>> FindByRecordIdAsync(int id)
        {
            return await _context.MedicalRecordItems.Where(p => p.MedicalRecordId == id)
                .Include(p => p.Medication).Include(p => p.Diagnosis).Include(p => p.Appointment).ToListAsync().ConfigureAwait(true);
        }

        public void Update(MedicalRecordItem medicalRecordItem)
        {
            _context.MedicalRecordItems.Update(medicalRecordItem);
        }

        public void Remove(MedicalRecordItem medicalRecordItem)
        {
            _context.MedicalRecordItems.Remove(medicalRecordItem);
        }
    }
}
