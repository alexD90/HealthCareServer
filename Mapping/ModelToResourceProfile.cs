using AutoMapper;
using HealthCare.API.Domain.Models;
using HealthCare.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Location, LocationResource>();
            CreateMap<Patient, PatientResource>();
            CreateMap<Practitioner, PractitionerResource>();
            CreateMap<Diagnosis, DiagnosisResource>();
            CreateMap<Medication, MedicationResource>();
            CreateMap<Appointment, AppointmentResource>();
            CreateMap<MedicalRecord, MedicalRecordResource>();
            CreateMap<MedicalRecordItem, MedicalRecordItemResource>();
            CreateMap<User, UserResource>();
        }
    }
}
