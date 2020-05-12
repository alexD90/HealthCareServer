﻿using HealthCare.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Resources
{
    public class SaveMedicalRecordResource
    {
        public string Identifer { get; set; }

        [Required]
        public int PatientId { get; set; }

        public DateTime Established { get; set; }

  
    }
}
