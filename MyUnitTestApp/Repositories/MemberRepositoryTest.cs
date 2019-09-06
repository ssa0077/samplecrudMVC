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
    class MemberRepositoryTest : IPatientRepository
    {        
        List<Patient> members = null;             

        public MemberRepositoryTest(List<Patient> mems)
        {
            members = mems;
        }

        public List<Patient> GetPatients()
        {
            return members;
        }

        public void InsertMember(Patient member)
        {
            members.Add(member);
        }

        public void UpdateMember(Patient mem)
        {
            int id = mem.MemberId;
            Patient memToUpdate = members.SingleOrDefault(x => x.MemberId == id);
            DeleteMember(memToUpdate.MemberId);
            members.Add(mem);
        }

        public void DeleteMember(int memberId)
        {
            Patient member = members.Where(x => x.MemberId == memberId).FirstOrDefault();
            members.Remove(member);           
        }

        public Patient GetMemberByID(int id)
        {
            return members.SingleOrDefault(m => m.MemberId == id);
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
