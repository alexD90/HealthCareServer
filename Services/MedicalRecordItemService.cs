using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Repositories;
using HealthCare.API.Domain.Services;
using HealthCare.API.Domain.Services.Communication;
using HealthCare.API.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Services
{
    public class MedicalRecordItemService : IMedicalRecordItemService
    {
        private readonly IMedicalRecordItemRepository _medicalRecordItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MedicalRecordItemService(IMedicalRecordItemRepository medicalRecordItemRepository, IUnitOfWork unitOfWork)
        {
            _medicalRecordItemRepository = medicalRecordItemRepository;
            _unitOfWork = unitOfWork;
        }

        public int CountMedicalRecordItems(string searchVal)
        {
            return _medicalRecordItemRepository.CountMedicalRecordItems(searchVal);
        }

        public async Task<IEnumerable<MedicalRecordItem>> ListAsync(int pageSize, int pageFirstIndex, string search)
        {
            return await _medicalRecordItemRepository.ListAsync(pageSize, pageFirstIndex, search);
        }

        public async Task<IEnumerable<MedicalRecordItem>> FindByRecordIdAsync(int id)
        {
            return await _medicalRecordItemRepository.FindByRecordIdAsync(id);
        }


        public async Task<MedicalRecordItemResponse> SaveAsync(MedicalRecordItem medicalRecordItem)
        {
            try
            {
                await _medicalRecordItemRepository.AddAsync(medicalRecordItem);
                await _unitOfWork.CompleteAsync();

                return new MedicalRecordItemResponse(medicalRecordItem);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new MedicalRecordItemResponse($"An error occurred when saving the medical record item: {ex.Message}");
            }
        }

        public async Task<MedicalRecordItemResponse> UpdateAsync(int id, MedicalRecordItem medicalRecordItem)
        {
            var existingMedicalRecordItem = await _medicalRecordItemRepository.FindByIdAsync(id);

            if (existingMedicalRecordItem == null)
                return new MedicalRecordItemResponse("Medical Record Item not found.");

            existingMedicalRecordItem.AppointmentId = medicalRecordItem.AppointmentId;
            existingMedicalRecordItem.MedicalRecordId = medicalRecordItem.MedicalRecordId;

            try
            {
                _medicalRecordItemRepository.Update(existingMedicalRecordItem);
                await _unitOfWork.CompleteAsync();

                return new MedicalRecordItemResponse(existingMedicalRecordItem);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new MedicalRecordItemResponse($"An error occurred when updating the Medical Record Item: {ex.Message}");
            }
        }

        public async Task<MedicalRecordItemResponse> DeleteAsync(int id)
        {
            var existingMedicalRecordItem = await _medicalRecordItemRepository.FindByIdAsync(id);

            if (existingMedicalRecordItem == null)
                return new MedicalRecordItemResponse("Medical Record Item not found.");

            try
            {
                _medicalRecordItemRepository.Remove(existingMedicalRecordItem);
                await _unitOfWork.CompleteAsync();

                return new MedicalRecordItemResponse(existingMedicalRecordItem);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new MedicalRecordItemResponse($"An error occurred when deleting the Medical Record Item: {ex.Message}");
            }
        }

    }
}
