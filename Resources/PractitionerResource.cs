using HealthCare.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Resources
{
    public class PractitionerResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Identifier { get; set; }
        public string Gender { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneWork { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
