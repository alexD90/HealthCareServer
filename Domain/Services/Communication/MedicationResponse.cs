using HealthCare.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Services.Communication
{
    public class MedicationResponse : BaseResponse
    {
        public Medication Medication { get; private set; }

        private MedicationResponse(bool success, string message, Medication medication) : base(success, message)
        {
            Medication = medication;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="medication">Saved medication.</param>
        /// <returns>Response.</returns>
        public MedicationResponse(Medication medication) : this(true, string.Empty, medication)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public MedicationResponse(string message) : this(false, message, null)
        { }
    }

}
