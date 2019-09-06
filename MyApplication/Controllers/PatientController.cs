using AutoMapper;
using MyApplication.Context;
using MyApplication.Helpers;
using MyApplication.Interfaces;
using MyApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApplication.Controllers
{
    public class PatientController : Controller
    {       
        private UniqueNumServiceHelper service = new UniqueNumServiceHelper();
        private UnitOfWork unitOfWork = null;

        public PatientController()
            : this(new UnitOfWork())
        {            
        }

        public PatientController(UnitOfWork uow)
        {
            this.unitOfWork = uow;
        }

        // GET: /Patients/

        public ActionResult Index()
        {
            List<Patient> patients = unitOfWork.PatientsRepository.GetPatients();
            return View(patients);           
        }

        public ViewResult Details(int id)
        {
            Patient pat = unitOfWork.PatientsRepository.GetPatientByID(id);
            return View(pat);
        }

        public ActionResult Create()
        {
            return View(new Patient());
        }

        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            try
            {
                if (patient.FirstName != "")
                {
                    if (Extensions.WarnInputError(patient.FirstName))
                    {

                        ModelState.AddModelError("Error", "First name - The characters '-', '[' ']', '*' and '!' are not allowed.");
                    }
                }

                if (patient.LastName != "")
                {
                    if (Extensions.WarnInputError(patient.LastName))
                    {

                        ModelState.AddModelError("Error", "Last name - The characters '-', '[' ']', '*' and '!' are not allowed");
                    }
                }

                try
                {
                    //Generate a unique identifier.                
                    patient.UniqueId = service.GenerateUniqueId();

                }
                catch
                {
                    //Redirect to error view if an exception is thrown.
                    return RedirectToAction("UniqueNumberGenError", "Error");
                }

                if (ModelState.IsValid)
                {                    
                    unitOfWork.PatientsRepository.InsertPatient(patient);
                    unitOfWork.PatientsRepository.Save();
                    return RedirectToAction("Details", "Patient", new { id = patient.PatientId });
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                  "Please try again.");
            }
            return View(patient);
        }

        public ActionResult Edit(int id)
        {
            Patient patient = unitOfWork.PatientsRepository.GetPatientByID(id);
            return View(patient);
        }

        [HttpPost]
        public ActionResult Edit(Patient patient)
        {
            try
            {
                if (patient.FirstName != "")
                {
                    if (Extensions.WarnInputError(patient.FirstName))
                    {

                        ModelState.AddModelError("Error", "First name - The characters '-', '[' ']', '*' and '!' are not allowed.");
                    }
                }

                if (patient.LastName != "")
                {
                    if (Extensions.WarnInputError(patient.LastName))
                    {

                        ModelState.AddModelError("Error", "Last name - The characters '-', '[' ']', '*' and '!' are not allowed");
                    }
                }

                if (ModelState.IsValid)
                {
                    unitOfWork.PatientsRepository.UpdatePatient(patient);
                    unitOfWork.PatientsRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, " +
                  "and if the problem persists see your system administrator.");
            }
            return View(patient);
        }

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, " +
                  "and if the problem persists see your system administrator.";
            }
            Patient patient = unitOfWork.PatientsRepository.GetPatientByID(id);
            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Patient book = unitOfWork.PatientsRepository.GetPatientByID(id);
                unitOfWork.PatientsRepository.DeletePatient(id);
                unitOfWork.PatientsRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                   new System.Web.Routing.RouteValueDictionary {
                    { "id", id },
                    { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
}
