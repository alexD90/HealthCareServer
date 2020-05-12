using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Repositories;
using HealthCare.API.Domain.Services;
using HealthCare.API.Domain.Services.Communication;

namespace HealthCare.API.Services
{
    public class MedicationService : IMedicationService
    {
        private IMedicationRepository _medicationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MedicationService(IMedicationRepository medicationRepository, IUnitOfWork unitOfWork)
        {
            this._medicationRepository = medicationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Medication>> ListAsync(int pageSize, int pageFirstIndex, string search)
        {
            return await _medicationRepository.ListAsync(pageSize, pageFirstIndex, search);
        }

        public int CountMedications(string searchVal)
        {
            return _medicationRepository.CountMedications(searchVal);
        }


        public async Task<MedicationResponse> SaveAsync(Medication medication)
        {
            try
            {
                await _medicationRepository.AddAsync(medication);
                await _unitOfWork.CompleteAsync();

                return new MedicationResponse(medication);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new MedicationResponse($"An error occurred when saving the medication: {ex.Message}");
            }
        }

        public async Task<MedicationResponse> UpdateAsync(int id, Medication medication)
        {
            var existingMedication = await _medicationRepository.FindByIdAsync(id);

            if (existingMedication == null)
                return new MedicationResponse("Medication not found.");

            existingMedication.Name = medication.Name;

            try
            {
                _medicationRepository.Update(existingMedication);
                await _unitOfWork.CompleteAsync();

                return new MedicationResponse(existingMedication);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new MedicationResponse($"An error occurred when updating medication: {ex.Message}");
            }
        }

        public async Task<MedicationResponse> DeleteAsync(int id)
        {
            var existingMedication = await _medicationRepository.FindByIdAsync(id);

            if (existingMedication == null)
                return new MedicationResponse("Medication not found.");

            try
            {
                _medicationRepository.Remove(existingMedication);
                await _unitOfWork.CompleteAsync();

                return new MedicationResponse(existingMedication);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new MedicationResponse($"An error occurred when deleting the medication: {ex.Message}");
            }
        }
    }
}