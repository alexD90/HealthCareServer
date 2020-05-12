using HealthCare.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Resources
{
    public class MedicalRecordItemResource
    {
        public int Id { get; set; }
        public int MedicalRecordId { get; set; }
        public MedicalRecordResource MedicalRecord { get; set; }

        public int AppointmentId { get; set; }
        public AppointmentResource Appointment { get; set; }

        public int DiagnosisId { get; set; }
        public Diagnosis Diagnosis { get; set; }

        public int MedicationId { get; set; }
        public Medication Medication { get; set; }
    }
}
