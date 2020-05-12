using HealthCare.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Services.Communication
{
    public class MedicalRecordResponse : BaseResponse
    {
        public MedicalRecord MedicalRecord { get; private set; }

        private MedicalRecordResponse(bool success, string message, MedicalRecord medicalRecord) : base(success, message)
        {
            MedicalRecord = medicalRecord;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="MedicalRecord">Saved medicalRecord.</param>
        /// <returns>Response.</returns>
        public MedicalRecordResponse(MedicalRecord medicalRecord) : this(true, string.Empty, medicalRecord)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public MedicalRecordResponse(string message) : this(false, message, null)
        { }
    }

}
