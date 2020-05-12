using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Repositories;
using HealthCare.API.Domain.Services;
using HealthCare.API.Domain.Services.Communication;

namespace HealthCare.API.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private IMedicalRecordRepository _medicalRecordRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository, IUnitOfWork unitOfWork)
        {
            this._medicalRecordRepository = medicalRecordRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MedicalRecord>> ListAsync(int pageSize, int pageFirstIndex, string search)
        {
            return await _medicalRecordRepository.ListAsync(pageSize, pageFirstIndex, search);
        }

        public  int CountMedicalRecords(string searchVal)
        {
            return  _medicalRecordRepository.CountMedicalRecords(searchVal);
        }

        public async Task<MedicalRecord> FindByPatientIdAsync(int id)
        {
            return await _medicalRecordRepository.FindByPatientIdAsync(id);
        }

        public MedicalRecord GetByPatient(int patientId)
        {
            return  _medicalRecordRepository.GetByPatient(patientId);
        }

        public async Task<MedicalRecordResponse> SaveAsync(MedicalRecord medicalRecord)
        {
            try
            {
                await _medicalRecordRepository.AddAsync(medicalRecord);
                await _unitOfWork.CompleteAsync();

                return new MedicalRecordResponse(medicalRecord);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new MedicalRecordResponse($"An error occurred when saving the medical record: {ex.Message}");
            }
        }

        public async Task<MedicalRecordResponse> UpdateAsync(int id, MedicalRecord medicalRecord)
        {
            var existingMedicalRecord = await _medicalRecordRepository.FindByIdAsync(id);

            if (existingMedicalRecord == null)
                return new MedicalRecordResponse("Medical Record not found.");

            existingMedicalRecord.Identifier = medicalRecord.Identifier;
            existingMedicalRecord.PatientId = medicalRecord.PatientId;

            try
            {
                _medicalRecordRepository.Update(existingMedicalRecord);
                await _unitOfWork.CompleteAsync();

                return new MedicalRecordResponse(existingMedicalRecord);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new MedicalRecordResponse($"An error occurred when updating the medical record: {ex.Message}");
            }
        }

        public async Task<MedicalRecordResponse> DeleteAsync(int id)
        {
            var existingMedicalRecord = await _medicalRecordRepository.FindByIdAsync(id);

            if (existingMedicalRecord == null)
                return new MedicalRecordResponse("Medical record not found.");

            try
            {
                _medicalRecordRepository.Remove(existingMedicalRecord);
                await _unitOfWork.CompleteAsync();

                return new MedicalRecordResponse(existingMedicalRecord);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new MedicalRecordResponse($"An error occurred when deleting the medical record: {ex.Message}");
            }
        }
    }
}