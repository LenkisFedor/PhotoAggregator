using System;
using System.Collections.Generic;

#nullable disable

namespace TestWebApp.Domain.Entity
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int AuthorId { get; set; }
        public int PhotographerId { get; set; }
        public string Description { get; set; }

        public virtual User Author { get; set; }
        public virtual Photographer Photographer { get; set; }
    }
}
