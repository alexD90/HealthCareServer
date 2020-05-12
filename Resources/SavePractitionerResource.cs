using HealthCare.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Resources
{
    public class SavePractitionerResource
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [StringLength(10)]
        public string Identifier { get; set; }


        public string Gender { get; set; }

        [MaxLength(30)]
        public string PhoneHome { get; set; }

        [MaxLength(30)]
        public string PhoneWork { get; set; }

        [MaxLength(30)]
        public string Mobile { get; set; }

        [MaxLength(40)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Note { get; set; }

    }
}
