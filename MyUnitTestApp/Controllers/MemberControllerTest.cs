
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApplication.Controllers;
using MyApplication.Models;
using MyUnitTestApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyUnitTestApp.Controllers
{
    [TestClass]
    public class MemberControllerTest
    {
        Patient mem1 = null;
        Patient mem2 = null;
        Patient mem3 = null;
        Patient mem4 = null;
        Patient mem5 = null;

        List<Patient> mems = null;
        MemberRepositoryTest memberRepository = null;
        PatientController controller = null;
        UnitOfWork uow = null;

        public MemberControllerTest()
        {
            mem1 = new Patient { MemberId = 11, FirstName = "test1", LastName = "test1", UniqueId = "c54be6de3c564e3faf7b24ca067f5eff", DateOfBirth = new DateTime(1990, 1, 1) };
            mem2 = new Patient { MemberId = 12, FirstName = "test2", LastName = "test2", UniqueId = "def0964c7efa48c78b277e101e997752", DateOfBirth = new DateTime(1991, 1, 1) };
            mem3 = new Patient { MemberId = 13, FirstName = "test3", LastName = "test3", UniqueId = "feb7aa4767424ffdaba74f6ed9b154e0", DateOfBirth = new DateTime(1992, 1, 1) };
            mem4 = new Patient { MemberId = 14, FirstName = "test4", LastName = "test4", UniqueId = "8076d497ef73421ab6d9798af14940f2", DateOfBirth = new DateTime(1993, 1, 1) };
            mem5 = new Patient { MemberId = 15, FirstName = "test5", LastName = "test5", UniqueId = "bfcaa0acabb24991aab565b66902df99", DateOfBirth = new DateTime(1994, 1, 1) };

            mems = new List<Patient>
            {
                mem1,
                mem2,
                mem3,
                mem4,
                mem5
            };
                                  
            memberRepository = new MemberRepositoryTest(mems);
            uow = new UnitOfWork(memberRepository);
            controller = new PatientController(uow);
        }

        [TestMethod]
        public void Index()
        {
            ViewResult result = controller.Index() as ViewResult;
            var model = (List<Patient>)result.ViewData.Model;            

            CollectionAssert.Contains(model, mem1);
            CollectionAssert.Contains(model, mem2);
            CollectionAssert.Contains(model, mem3);
            CollectionAssert.Contains(model, mem4);
            CollectionAssert.Contains(model, mem5);
        }

        [TestMethod]
        public void Details()
        {
            ViewResult result = controller.Details(11) as ViewResult;
            Assert.AreEqual(result.Model, mem1);
        }

        [TestMethod]
        public void Create()
        {
            Patient newMember = new Patient { MemberId = 16, FirstName = "Joe", LastName = "Bloggs", UniqueId = "Test090090AAAkJJJkjk", DateOfBirth = new DateTime(1980, 1, 1) };
            controller.Create(newMember);
            List<Patient> mems = memberRepository.GetPatients();

            CollectionAssert.Contains(mems, newMember);
        }

        [TestMethod]
        public void Edit()
        {
            Patient editMember = new Patient { MemberId = 11, FirstName = "newFirstName", LastName = "newLastName", UniqueId = "TestUpdate121243124", DateOfBirth = new DateTime(1999, 09, 09) };
            controller.Edit(editMember);
            List<Patient> mems = memberRepository.GetPatients();

            CollectionAssert.Contains(mems, editMember);
        }

        [TestMethod]
        public void Delete()
        {
            controller.Delete(11, false);
            controller.DeleteConfirmed(11);
            List<Patient> mems = memberRepository.GetPatients();

            CollectionAssert.DoesNotContain(mems, mem1);
        }

    }

}