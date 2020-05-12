using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Models
{
    public class Practitioner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public IList<Patient> Patients { get; set; } = new List<Patient>();

    }
}
