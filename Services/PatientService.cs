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
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
        {
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Patient>> ListAsync(int pageSize, int pageFirstIndex, string search)
        {
            return await _patientRepository.ListAsync(pageSize, pageFirstIndex, search);
        }


        public int CountPatients(string searchVal)
        {
            return _patientRepository.CountPatients(searchVal);
        }

        public async Task<PatientResponse> SaveAsync(Patient patient)
        {
            try
            {
                await _patientRepository.AddAsync(patient);
                await _unitOfWork.CompleteAsync();

                return new PatientResponse(patient);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new PatientResponse($"An error occurred when saving the patient: {ex.Message}");
            }
        }

        public async Task<PatientResponse> UpdateAsync(int id, Patient patient)
        {
            var existingPatient = await _patientRepository.FindByIdAsync(id);

            if (existingPatient == null)
                return new PatientResponse("Patient not found.");

            existingPatient.FirstName = patient.FirstName;
            existingPatient.LastName = patient.LastName;
            existingPatient.PersonalNumber = patient.PersonalNumber;
            existingPatient.PractitionerId = patient.PractitionerId;

            try
            {
                _patientRepository.Update(existingPatient);
                await _unitOfWork.CompleteAsync();

                return new PatientResponse(existingPatient);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new PatientResponse($"An error occurred when updating the patient: {ex.Message}");
            }
        }

        public async Task<PatientResponse> DeleteAsync(int id)
        {
            var existingPatient = await _patientRepository.FindByIdAsync(id);

            if (existingPatient == null)
                return new PatientResponse("Patient not found.");

            try
            {
                _patientRepository.Remove(existingPatient);
                await _unitOfWork.CompleteAsync();

                return new PatientResponse(existingPatient);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new PatientResponse($"An error occurred when deleting the patient: {ex.Message}");
            }
        }

    }
}
