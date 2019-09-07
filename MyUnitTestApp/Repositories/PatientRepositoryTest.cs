using MyApplication.Context;
using MyApplication.Interfaces;
using MyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnitTestApp.Repositories
{
    class PatientRepositoryTest : IPatientRepository
    {        
        List<Patient> patients = null;             

        public PatientRepositoryTest(List<Patient> pats)
        {
            patients = pats;
        }

        public List<Patient> GetPatients()
        {
            return patients;
        }

        public void InsertPatient(Patient pat)
        {
            patients.Add(pat);
        }

        public void UpdatePatient(Patient pat)
        {
            int id = pat.PatientId;
            Patient memToUpdate = patients.SingleOrDefault(x => x.PatientId == id);
            DeletePatient(memToUpdate.PatientId);
            patients.Add(pat);
        }

        public void DeletePatient(int patientId)
        {
            Patient patient = patients.Where(x => x.PatientId == patientId).FirstOrDefault();
            patients.Remove(patient);           
        }

        public Patient GetPatientByID(int id)
        {
            return patients.SingleOrDefault(m => m.PatientId == id);
        }

        public void Save()
        {
            //Nothing to implement here.
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
