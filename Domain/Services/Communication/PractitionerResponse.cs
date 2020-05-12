using HealthCare.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Services.Communication
{
    public class PractitionerResponse : BaseResponse
    {
        public Practitioner Practitioner { get; private set; }

        private PractitionerResponse(bool success, string message, Practitioner practitioner) : base(success, message)
        {
            Practitioner = practitioner;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Location">Saved Location.</param>
        /// <returns>Response.</returns>
        public PractitionerResponse(Practitioner practitioner) : this(true, string.Empty, practitioner)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public PractitionerResponse(string message) : this(false, message, null)
        { }
    }
}
