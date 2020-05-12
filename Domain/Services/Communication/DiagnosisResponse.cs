using HealthCare.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Services.Communication
{
    public class DiagnosisResponse : BaseResponse
    {
        public Diagnosis Diagnosis { get; private set; }

        private DiagnosisResponse(bool success, string message, Diagnosis diagnosis) : base(success, message)
        {
            Diagnosis = diagnosis;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Location">Saved Location.</param>
        /// <returns>Response.</returns>
        public DiagnosisResponse(Diagnosis diagnosis) : this(true, string.Empty, diagnosis)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public DiagnosisResponse(string message) : this(false, message, null)
        { }
    }

}
