using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedOrganization.DAL.Model;
using MedOrganization.DAL;

namespace MedOrganization.Service
{
    public class AdditionModele
    {
        List<Patient> Patients;
        List<Organization> Organizations;
        public AdditionModele()
        {
            Patients.AddRange(AddToDB.ReturnAllPatient());
            Organizations.AddRange(AddToDB.ReturnAllOrganization());
        }
        public List<Patient> Search(string fname, string lname)
        {
            return Patients.Where(x => x.FName == fname && x.LName == lname).ToList();
        }
        public List<Patient> Search(int iin)
        {
            return Patients.Where(x => x.IIN == iin).ToList();
        }
        public bool ChangeAttachmentStatus(RequestToAdd request, Status status)
        {
            request.Status = status;
            try
            {
                if (status == Status.Approved)
                {
                    AddToDB.UpdatePatient(request.Patient);
                    AddToDB.UpdateOrganization(request.Organization);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
