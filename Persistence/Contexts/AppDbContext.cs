using HealthCare.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Practitioner> Practitioners { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<MedicalRecordItem> MedicalRecordItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

         protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");

            builder.Entity<Location>().ToTable("Locations");
            builder.Entity<Location>().HasKey(p => p.Id);
            builder.Entity<Location>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Location>().Property(p => p.Name).IsRequired().HasMaxLength(30);

    /*        builder.Entity<Location>().HasData
            (
                new Location { Id = 100, Name = "Room1" }, // Id set manually due to in-memory provider
                new Location { Id = 101, Name = "Room2" }
            );*/

            builder.Entity<Medication>().ToTable("Medications");
            builder.Entity<Medication>().HasKey(p => p.Id);
            builder.Entity<Medication>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Medication>().Property(p => p.Name).IsRequired().HasMaxLength(30);

    /*        builder.Entity<Medication>().HasData
            (
                new Medication { Id = 100, Name = "Brufen" }, // Id set manually due to in-memory provider
                new Medication { Id = 101, Name = "Paracetamol" }
            );*/

            builder.Entity<Diagnosis>().ToTable("Diagnoses");
            builder.Entity<Diagnosis>().HasKey(p => p.Id);
            builder.Entity<Diagnosis>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Diagnosis>().Property(p => p.Name).IsRequired().HasMaxLength(30);

        /*    builder.Entity<Diagnosis>().HasData
            (
                new Diagnosis { Id = 100, Name = "Asthma", NameLat = "AsthmaBronchialis", ExternalCode = "ATH" }, // Id set manually due to in-memory provider
                new Diagnosis { Id = 101, Name = "Dhermatits", NameLat = "Tetetete", ExternalCode = "DHR" },
                new Diagnosis { Id = 102, Name = "Dhermatits", NameLat = "Tetetete", ExternalCode = "DHR" },
                new Diagnosis { Id = 103, Name = "Dhermatits", NameLat = "Tetetete", ExternalCode = "DHR" },
                new Diagnosis { Id = 104, Name = "Dhermatits", NameLat = "Tetetete", ExternalCode = "DHR" },
                new Diagnosis { Id = 105, Name = "Dhermatits", NameLat = "Tetetete", ExternalCode = "DHR" },
                new Diagnosis { Id = 106, Name = "Dhermatits", NameLat = "Tetetete", ExternalCode = "DHR" },
                new Diagnosis { Id = 107, Name = "Dhermatits", NameLat = "Tetetete", ExternalCode = "DHR" },
                new Diagnosis { Id = 108, Name = "Dhermatits", NameLat = "Tetetete", ExternalCode = "DHR" },
                new Diagnosis { Id = 109, Name = "Dhermatits", NameLat = "Tetetete", ExternalCode = "DHR" },
                new Diagnosis { Id = 110, Name = "Dhermatits", NameLat = "Tetetete", ExternalCode = "DHR" },
                new Diagnosis { Id = 111, Name = "Dhermatits", NameLat = "Tetetete", ExternalCode = "DHR" },
                new Diagnosis { Id = 112, Name = "Dhermatits", NameLat = "Tetetete", ExternalCode = "DHR" },
                new Diagnosis { Id = 113, Name = "Dhermatits", NameLat = "Tetetete", ExternalCode = "DHR" },
                new Diagnosis { Id = 114, Name = "Dhermatits", NameLat = "Tetetete", ExternalCode = "DHR" },
                new Diagnosis { Id = 115, Name = "Dhermatits", NameLat = "Tetetete", ExternalCode = "DHR" },
                new Diagnosis { Id = 116, Name = "Dhermatits", NameLat = "Tetetete", ExternalCode = "DHR" },
                new Diagnosis { Id = 117, Name = "Dhermatits", NameLat = "Tetetete", ExternalCode = "DHR" },
                new Diagnosis { Id = 118, Name = "Dhermatits", NameLat = "Tetetete", ExternalCode = "DHR" },
                new Diagnosis { Id = 119, Name = "Dhermatits", NameLat = "Tetetete", ExternalCode = "DHR" },
                new Diagnosis { Id = 120, Name = "Dhermatits", NameLat = "Tetetete", ExternalCode = "DHR" }
            );
*/
            builder.Entity<Practitioner>().ToTable("Practitioners");
            builder.Entity<Practitioner>().HasKey(p => p.Id);
            builder.Entity<Practitioner>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Practitioner>().Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<Practitioner>().Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Practitioner>().Property(p => p.Title).IsRequired();
            builder.Entity<Practitioner>().HasMany(p => p.Patients).WithOne(p => p.Practitioner).HasForeignKey(p => p.PractitionerId);

          /*  builder.Entity<Practitioner>().HasData
    (
        new Practitioner
        {
            Id = 105,
            FirstName = "Aleksandra",
            LastName = "Dragojevic",
            Title = "sdfsdfsdf"
        },
        new Practitioner
        {
            Id = 106,
            FirstName = "DDDDD",
            LastName = "Dragojeviccc",
            Title = "123456ccc"
        }

      
    );*/
          

            builder.Entity<Patient>().ToTable("Patients");
            builder.Entity<Patient>().HasKey(p => p.Id);
            builder.Entity<Patient>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Patient>().Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<Patient>().Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Patient>().Property(p => p.PersonalNumber).IsRequired();

          /*  builder.Entity<Patient>().HasData
    (
        new Patient
        {
            Id = 105,
            FirstName = "Aleksandra",
            LastName = "Dragojevic",
            PersonalNumber = "123456",
            PractitionerId = 105
        },
        new Patient
        {
            Id = 106,
            FirstName = "Aleksandra",
            LastName = "
            
            
            
            cc",
            PersonalNumber = "123456ccc",
            PractitionerId = 105
        }
    );*/


            builder.Entity<Appointment>().ToTable("Appointments");
            builder.Entity<Appointment>().HasKey(p => p.Id);
            builder.Entity<Appointment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Appointment>().Property(p => p.Date);
            builder.Entity<Appointment>().Property(p => p.StartTime);
            builder.Entity<Appointment>().Property(p => p.EndTime);

          /*  builder.Entity<Appointment>().HasData
    (
        new Appointment
        {
            Id = 105,
            PractitionerId = 105,
            PatientId = 105,
            Date = new System.DateTime(2020, 5, 20)
        },
        new Appointment
        {
            Id = 106,
            PractitionerId = 105,
            PatientId = 105,
            Date = new System.DateTime(2020, 5, 20)
        }
    );*/


            builder.Entity<MedicalRecord>().ToTable("MedicalRecords");
            builder.Entity<MedicalRecord>().HasKey(p => p.Id);
            builder.Entity<MedicalRecord>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<MedicalRecord>().Property(p => p.Identifier);
  
          /*  builder.Entity<MedicalRecord>().HasData
    (
        new MedicalRecord
        {
            Id = 105,
            Identifier = "ttt",
            PatientId = 105,
            Established =  new System.DateTime(2020, 5, 20)
        }*//*,
        new MedicalRecord
        {
            Id = 106,
            Identifier = "bbb",
            PatientId = 106,
            Established = new System.DateTime(2020, 5, 20)

        }*//*
    );
*/
            builder.Entity<MedicalRecordItem>().ToTable("MedicalRecordItem");
            builder.Entity<MedicalRecordItem>().HasKey(p => p.Id);
            builder.Entity<MedicalRecordItem>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
          //  builder.Entity<MedicalRecordItem>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
           // builder.Entity<MedicalRecordItem>().HasOne(f => f.MedicalRecord).WithMany(b => b.Items).HasForeignKey(p => p.MedicalRecordId).OnDelete(DeleteBehavior.NoAction);

           /* builder.Entity<MedicalRecordItem>().HasData
           (
        new MedicalRecordItem
        {
            Id = 105,
            AppointmentId = 105,
            MedicalRecordId = 105
        }
    );*/
        }
    }
    
}