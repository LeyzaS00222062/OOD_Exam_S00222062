using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace OOD_Exam_S00222062
{
    public class PatientData : DbContext 
    {
        // DbSet<Patient> Patients { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        // Constructor
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "PatientData.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }


        // Patient data 
        Patient p1 = new Patient()
        {
            FirstName = "John",
            Surname = "Smith",
            DOB = new DateTime(2000, 01, 31),
            ContactNumber = "086 123 4567"
        };

        Patient p2 = new Patient()
        {
            FirstName = "Mary",
            Surname = "Jones",
            DOB = new DateTime(1980, 06, 15),
            ContactNumber = "087 323 2585"
        };

        Patient p3 = new Patient()
        {
            FirstName = "Jim",
            Surname = "Ryan",
            DOB = new DateTime(2005, 03, 10),
            ContactNumber = "086 568 7896"
        };
    }

}

