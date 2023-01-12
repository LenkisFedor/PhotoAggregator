using System;
using System.Collections.Generic;

#nullable disable

namespace TestWebApp.Domain.Entity
{
    public partial class User
    {
        public User()
        {
            Requests = new HashSet<Request>();
            Reviews = new HashSet<Review>();
        }

        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserPass { get; set; }
        public string UserRole { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
