using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Repositories;
using HealthCare.API.Domain.Services;
using HealthCare.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Services
{
    public class DiagnosisService : IDiagnosisService
    {
        private IDiagnosisRepository _diagnosisRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DiagnosisService(IDiagnosisRepository diagnosisRepository, IUnitOfWork unitOfWork)
        {
            this._diagnosisRepository = diagnosisRepository;
            _unitOfWork = unitOfWork;
        }

        public int CountDiagnoses(string searchVal)
        {
            return _diagnosisRepository.CountDiagnoses(searchVal);
        }

        public async Task<IEnumerable<Diagnosis>> ListAsync(int pageSize, int pageFirstIndex, string search)
        {
            return await _diagnosisRepository.ListAsync(pageSize, pageFirstIndex, search);
        }

        public async Task<DiagnosisResponse> SaveAsync(Diagnosis diganosis)
        {
            try
            {
                await _diagnosisRepository.AddAsync(diganosis);
                await _unitOfWork.CompleteAsync();

                return new DiagnosisResponse(diganosis);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new DiagnosisResponse($"An error occurred when saving the diganosis: {ex.Message}");
            }
        }

        public async Task<DiagnosisResponse> UpdateAsync(int id, Diagnosis diagnosis)
        {
            var existingDiagnosis = await _diagnosisRepository.FindByIdAsync(id);

            if (existingDiagnosis == null)
                return new DiagnosisResponse("Diagnosis not found.");

            existingDiagnosis.Name = diagnosis.Name;

            try
            {
                _diagnosisRepository.Update(existingDiagnosis);
                await _unitOfWork.CompleteAsync();

                return new DiagnosisResponse(existingDiagnosis);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new DiagnosisResponse($"An error occurred when updating the diagnosis: {ex.Message}");
            }
        }

        public async Task<DiagnosisResponse> DeleteAsync(int id)
        {
            var existingDiagnosis = await _diagnosisRepository.FindByIdAsync(id);

            if (existingDiagnosis == null)
                return new DiagnosisResponse("Diagnosis not found.");

            try
            {
                _diagnosisRepository.Remove(existingDiagnosis);
                await _unitOfWork.CompleteAsync();

                return new DiagnosisResponse(existingDiagnosis);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new DiagnosisResponse($"An error occurred when deleting the diagnosis: {ex.Message}");
            }
        }

    }
}
