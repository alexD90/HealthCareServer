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
    public class DiagnosisRepository : BaseRepository, IDiagnosisRepository
    {
        public DiagnosisRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Diagnosis>> ListAsync(int pageSize, int pageFirstIndex, string searchVal)
        {
            if (searchVal == null || (searchVal != null) && (searchVal.Trim().Equals("") || searchVal.Equals("null")))
            {
                if (pageSize != 0)
                {
                    return await _context.Diagnoses.Skip((pageFirstIndex) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(true);
                }
                else
                {
                    return await _context.Diagnoses.ToListAsync().ConfigureAwait(true);
                }
            }
            else {
            return await _context.Diagnoses.Where(p => p.Name.ToLower().Contains(searchVal.ToLower())
            || p.NameLat.ToLower().Contains(searchVal.ToLower()) || p.ExternalCode.ToLower().Contains(searchVal.ToLower())).Take(pageSize).ToListAsync().ConfigureAwait(true);
        }
        }


        public int CountDiagnoses(string searchVal)
        {
            if (searchVal == null)
            {
                searchVal = "";
            }
            return _context.Diagnoses.Where(p => p.Name.ToLower().Contains(searchVal.ToLower())
            || p.NameLat.ToLower().Contains(searchVal.ToLower()) || p.ExternalCode.ToLower().Contains(searchVal.ToLower())).Count();
        }


        public async Task AddAsync(Diagnosis diagnosis)
        {
            await _context.Diagnoses.AddAsync(diagnosis);
        }

        public async Task<Diagnosis> FindByIdAsync(int id)
        {
            return await _context.Diagnoses.FindAsync(id);
        }

        public void Update(Diagnosis diagnosis)
        {
            _context.Diagnoses.Update(diagnosis);
        }

        public void Remove(Diagnosis diagnosis)
        {
            _context.Diagnoses.Remove(diagnosis);
        }
    }
}
