using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedOrganization.DAL.Model
{
    public class Patient: IUser
    {
        public int PatientId { get; set; }
        public int IIN { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public DateTime DoB { get; set; }
        public Organization Organization { get; set; }

        public Patient() { }
        public Patient(DateTime dob) { DoB = dob; }
        public Patient(int iin) { IIN = iin; }

        public Patient(string fname, string lname) : this(fname, lname, "") { }
        public Patient(string fname, string lname, string mname)
        {
            FName = fname;
            LName = lname;
            MName = mname;
        }
    }
}
