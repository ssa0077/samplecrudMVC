using MyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Interfaces
{
    public interface IPatientRepository : IDisposable
    {
        List<Patient> GetPatients();
        Patient GetPatientByID(int patientId);
        void InsertPatient(Patient patient);
        void DeletePatient(int patientID);
        void UpdatePatient(Patient patient);
        void Save();
    }
}
