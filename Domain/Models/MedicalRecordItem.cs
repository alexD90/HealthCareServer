using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.API.Domain.Models
{
    public class MedicalRecordItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public  int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public int DiagnosisId { get; set; }
        public int MedicationId { get; set; }

        public Diagnosis Diagnosis { get; set; }

        public Medication Medication { get; set; }

    }
}
