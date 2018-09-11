using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedOrganization.DAL.Model
{
    public enum Status { Create, Approved, Cancel }
    public class RequestToAdd
    {
        public int RequestToAddId { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime StatusDate { get; set; }
        public Patient Patient { get; set; }
        public Organization Organization { get; set; }

        private Status Status_;
        public Status Status
        {
            get => Status_;
            set
            {
                if (value == Status.Approved || value == Status.Cancel)
                    StatusDate = DateTime.Now;

                Status_ = value;
            }
        }
    }
}
