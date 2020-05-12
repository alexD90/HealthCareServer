using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Models
{
    public class MedicalRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Identifier { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public DateTime  Established { get; set; }


        public IList<MedicalRecordItem> Items { get; set; } = new List<MedicalRecordItem>();

    }
}
