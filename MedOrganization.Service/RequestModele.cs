using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedOrganization.DAL.Model;
using MedOrganization.DAL;

namespace MedOrganization.Service
{
    public class RequestModele
    {
        public void AddRequest(RequestToAdd request)
        {
            AddToDB.CreateRequest(request);
        }
    }
}
