using HealthCare.API.Domain.Models;
using HealthCare.API.Resources;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveLocationResource, Location>();
            CreateMap<SavePatientResource, Patient>();
            CreateMap<SavePractitionerResource, Practitioner>();
            CreateMap<SaveDiagnosisResource, Diagnosis>();
            CreateMap<SaveMedicationResource, Medication>();
            CreateMap<SaveAppointmentResource, Appointment>();
            CreateMap<SaveMedicalRecordResource, MedicalRecord>();
            CreateMap<SaveMedicalRecordItemResource, MedicalRecordItem>();
            CreateMap<SaveUserResource, User>();
        }
    }
}
