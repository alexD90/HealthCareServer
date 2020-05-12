using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Resources
{
    public class MedicationResource
    {
        public short Id { get; set; }

        public string Code { get; set; }
        public string CodeAtc { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
