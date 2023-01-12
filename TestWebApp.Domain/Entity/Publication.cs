using System;
using System.Collections.Generic;

#nullable disable

namespace TestWebApp.Domain.Entity
{
    public partial class Publication
    {
        public int PublicationId { get; set; }
        public TimeSpan PublicationDate { get; set; }
        public int AuthorId { get; set; }

        public string sourceString { get; set; }

        public virtual Photographer Author { get; set; }
    }
}
