using System;
using System.Collections.Generic;

#nullable disable

namespace TestWebApp.Domain.Entity
{
    public partial class Request
    {
        public int RequestId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExecutionDate { get; set; }
        public int ServiceTypeId { get; set; }
        public int CleintId { get; set; }
        public int PhotographerId { get; set; }

        public virtual User Cleint { get; set; }
        public virtual Photographer Photographer { get; set; }
        public virtual Service ServiceType { get; set; }
    }
}
