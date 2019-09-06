using MyApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyApplication.Context
{
    public class PatientContext : DbContext
    {
        public PatientContext()
            : base("name=PatientConnectionString")
        {
        }
        public DbSet<Patient> Patients { get; set; }
    }
}