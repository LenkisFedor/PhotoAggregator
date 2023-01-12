using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Domain.Entity;

namespace TestWebApp.Domain.ViewModels.Service
{
    public class ServiceViewModel
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }

        public virtual ICollection<TestWebApp.Domain.Entity.Request> Requests { get; set; }
    }
}
