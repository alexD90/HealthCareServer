using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Models
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? PractitionerId { get; set; }
        public Practitioner Practitioner { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }

        public DateTime  Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public Boolean Canceled { get; set; }
        public Boolean Finished { get; set; }
    }
}
