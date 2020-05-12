using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Resources
{
    public class SaveLocationResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
