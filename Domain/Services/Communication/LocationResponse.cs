using HealthCare.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Services.Communication
{
    public class LocationResponse : BaseResponse
    {
        public Location Location { get; private set; }

        private LocationResponse(bool success, string message, Location location) : base(success, message)
        {
            Location = location;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Location">Saved Location.</param>
        /// <returns>Response.</returns>
        public LocationResponse(Location Location) : this(true, string.Empty, Location)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public LocationResponse(string message) : this(false, message, null)
        { }
    }

}
