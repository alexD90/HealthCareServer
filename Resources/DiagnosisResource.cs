using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Resources
{
    public class DiagnosisResource
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string NameLat { get; set; }
        public string ExternalCode { get; set; }
    }
}
