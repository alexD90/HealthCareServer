

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Resources
{
    public class SaveMedicalRecordItemResource
    {
        public int MedicalRecordId { get; set; }
        public int AppointmentId { get; set; }
        public int MedicationId { get; set; }
        public int DiagnosisId { get; set; }
    }
}
