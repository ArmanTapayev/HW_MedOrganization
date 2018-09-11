using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedOrganization.DAL.Model
{
    public interface IUser
    {
        string FName { get; set; }
        string LName { get; set; }
        string MName { get; set; }
        DateTime DoB { get; set; }
    }
}
