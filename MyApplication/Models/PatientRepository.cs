using MyApplication.Context;
using MyApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyApplication.Models
{
    public class PatientRepository : IPatientRepository
    {
        private PatientContext _context = null;
 
        public PatientRepository(PatientContext patientContext)
        {
            this._context = patientContext;
        }
 
        public List<Patient> GetPatients()
        {
            return _context.Patients.ToList();
        }
 
        public Patient GetPatientByID(int id)
        {
            return _context.Patients.Find(id);
        }
 
        public void InsertPatient(Patient patient)
        {           
            _context.Patients.Add(patient);
        }
 
        public void DeletePatient(int patientID)
        {
            Patient patient = _context.Patients.Find(patientID);
            _context.Patients.Remove(patient);
        }
 
        public void UpdatePatient(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
        }
 
        public void Save()
        {
            _context.SaveChanges();
        }
 
        private bool disposed = false;
 
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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