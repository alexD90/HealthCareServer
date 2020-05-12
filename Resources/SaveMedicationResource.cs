using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Resources
{
    public class SaveMedicationResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Code { get; set; }

        [Required]
        [MaxLength(3)]
        public string CodeAtc { get; set; }

        [Required]
        [MaxLength(1)]
        public string Status { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }
}
