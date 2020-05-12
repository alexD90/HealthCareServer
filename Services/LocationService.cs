using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Repositories;
using HealthCare.API.Domain.Services;
using HealthCare.API.Domain.Services.Communication;

namespace HealthCare.API.Services
{
    public class LocationService : ILocationService
    {
        private ILocationRepository _locationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LocationService(ILocationRepository locationRepository, IUnitOfWork unitOfWork)
        {
            this._locationRepository = locationRepository;
            _unitOfWork = unitOfWork;
        }

        public int CountLocations(string searchVal)
        {
            return _locationRepository.CountLocations(searchVal);
        }

        public async Task<IEnumerable<Location>> ListAsync(int pageSize, int pageFirstIndex, string search)
        {
            return await _locationRepository.ListAsync(pageSize, pageFirstIndex, search);
        }

        public async Task<LocationResponse> SaveAsync(Location Location)
        {
            try
            {
                await _locationRepository.AddAsync(Location);
                await _unitOfWork.CompleteAsync();

                return new LocationResponse(Location);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new LocationResponse($"An error occurred when saving the Location: {ex.Message}");
            }
        }

        public async Task<LocationResponse> UpdateAsync(int id, Location Location)
        {
            var existingLocation = await _locationRepository.FindByIdAsync(id);

            if (existingLocation == null)
                return new LocationResponse("Location not found.");

            existingLocation.Name = Location.Name;

            try
            {
                _locationRepository.Update(existingLocation);
                await _unitOfWork.CompleteAsync();

                return new LocationResponse(existingLocation);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new LocationResponse($"An error occurred when updating the Location: {ex.Message}");
            }
        }

        public async Task<LocationResponse> DeleteAsync(int id)
        {
            var existingLocation = await _locationRepository.FindByIdAsync(id);

            if (existingLocation == null)
                return new LocationResponse("Location not found.");

            try
            {
                _locationRepository.Remove(existingLocation);
                await _unitOfWork.CompleteAsync();

                return new LocationResponse(existingLocation);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new LocationResponse($"An error occurred when deleting the Location: {ex.Message}");
            }
        }
    }
}