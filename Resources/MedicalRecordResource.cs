using HealthCare.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Resources
{
    public class MedicalRecordResource
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public int PatientId { get; set; }
        public PatientResource Patient { get; set; }

        public DateTime Established { get; set; }
        public List<MedicalRecordItem> Items { get; set; }
    }
}
