using System;
using System.Collections.Generic;

#nullable disable

namespace TestWebApp.Domain.Entity
{
    public partial class Service
    {
        public Service()
        {
            Requests = new HashSet<Request>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
