using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Resources
{
    public class AppointmentResource
    {
        public int Id { get; set; }
        public int PatientId { get; set; }

        public PatientResource Patient { get; set; }
        public int PractitionerId { get; set; }

        public PractitionerResource Practitioner { get; set; }
        public int LocationId { get; set; }
        public LocationResource Location { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public Boolean Canceled { get; set; }
        public Boolean Finished { get; set; }
    }
}
