using System;
using System.Collections.Generic;

#nullable disable

namespace TestWebApp.Domain.Entity
{
    public partial class Client
    {
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public long? ClientNumber { get; set; }
        public string ClientEmail { get; set; }
        public int? ClientId { get; set; }

        public virtual User ClientNavigation { get; set; }
    }


}
