using System;
using System.Collections.Generic;

#nullable disable

namespace TestWebApp.Domain.Entity
{
    public partial class Photographer
    {
        public Photographer()
        {
            Publications = new HashSet<Publication>();
            Requests = new HashSet<Request>();
            Reviews = new HashSet<Review>();
        }

        public int PhotographerId { get; set; }
        public string PhotographerName { get; set; }
        public string PhotographerEmail { get; set; }
        public short PhotographerWorkExperience { get; set; }

        public virtual ICollection<Publication> Publications { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
