using HealthCare.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Services.Communication
{
    public class MedicalRecordItemResponse : BaseResponse
    {
        public MedicalRecordItem MedicalRecordItem { get; private set; }

        private MedicalRecordItemResponse(bool success, string message, MedicalRecordItem medicalRecordItem) : base(success, message)
        {
            MedicalRecordItem = medicalRecordItem;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="MedicalRecordItem">Saved medicalRecordItem.</param>
        /// <returns>Response.</returns>
        public MedicalRecordItemResponse(MedicalRecordItem medicalRecordItem) : this(true, string.Empty, medicalRecordItem)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public MedicalRecordItemResponse(string message) : this(false, message, null)
        { }
    }

}
