using HealthCare.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Services.Communication
{
    public class AppointmentResponse : BaseResponse
    {
        public Appointment Appointment { get; private set; }

        private AppointmentResponse(bool success, string message, Appointment appointment) : base(success, message)
        {
            Appointment = appointment;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Appointment">Saved appointment.</param>
        /// <returns>Response.</returns>
        public AppointmentResponse(Appointment appointment) : this(true, string.Empty, appointment)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public AppointmentResponse(string message) : this(false, message, null)
        { }
    }

}
