using MyApplication.Context;
using MyApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApplication.Models
{
    public class UnitOfWork : IDisposable
    {
        private PatientContext context = null;
       
        public UnitOfWork()
        {
            context = new PatientContext();
            PatientsRepository = new PatientRepository(context);
        }
     
        public UnitOfWork(IPatientRepository memRepo)
        {
            PatientsRepository = memRepo;
        }

        public IPatientRepository PatientsRepository
        {
            get;
            private set;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                context = null;
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

    }
}