using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Repositories;
using HealthCare.API.Domain.Services;
using HealthCare.API.Domain.Services.Communication;

namespace HealthCare.API.Services
{
    public class PractitionerService : IPractitionerService
    {
        private IPractitionerRepository _practitionerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PractitionerService(IPractitionerRepository practitionerRepository, IUnitOfWork unitOfWork)
        {
            this._practitionerRepository = practitionerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Practitioner>> ListAsync(int pageSize, int pageFirstIndex, string search)
        {
            return await _practitionerRepository.ListAsync(pageSize, pageFirstIndex, search);
        }


        public int CountPractitioners(string search)
        {
            return _practitionerRepository.CountPractitioners(search);
        }

        public async Task<PractitionerResponse> SaveAsync(Practitioner practitioner)
        {
            try
            {
                await _practitionerRepository.AddAsync(practitioner);
                await _unitOfWork.CompleteAsync();

                return new PractitionerResponse(practitioner);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new PractitionerResponse($"An error occurred when saving the practitioner: {ex.Message}");
            }
        }

        public async Task<PractitionerResponse> UpdateAsync(int id, Practitioner practitioner)
        {
            var existingPractitioner = await _practitionerRepository.FindByIdAsync(id);

            if (existingPractitioner == null)
                return new PractitionerResponse("Practitioner not found.");

            existingPractitioner.FirstName = practitioner.FirstName;
            existingPractitioner.LastName = practitioner.LastName;
            existingPractitioner.Title = practitioner.Title;

            try
            {
                _practitionerRepository.Update(existingPractitioner);
                await _unitOfWork.CompleteAsync();

                return new PractitionerResponse(existingPractitioner);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new PractitionerResponse($"An error occurred when updating the practitioner: {ex.Message}");
            }
        }

        public async Task<PractitionerResponse> DeleteAsync(int id)
        {
            var existingPractitioner = await _practitionerRepository.FindByIdAsync(id);

            if (existingPractitioner == null)
                return new PractitionerResponse("Location not found.");

            try
            {
                _practitionerRepository.Remove(existingPractitioner);
                await _unitOfWork.CompleteAsync();

                return new PractitionerResponse(existingPractitioner);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new PractitionerResponse($"An error occurred when deleting the practitioner: {ex.Message}");
            }
        }
    }
}