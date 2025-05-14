using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;


namespace OOD_Exam_S00222062
{
    public class PatientData : DbContext 
    {
        public DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "PatientsData.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }

}

