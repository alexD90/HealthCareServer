
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Resources
{
    public class SaveAppointmentResource
    {
        [Required]
        public int PatientId { get; set; }

        [Required]
        public int LocationId { get; set; }
       
        [Required]
        public int PractitionerId { get; set; }  
        
        public MedicalRecordItemResource MedicalRecordItem { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }


        public Boolean Canceled { get; set; }
        public Boolean Finished { get; set; }
    }
}
