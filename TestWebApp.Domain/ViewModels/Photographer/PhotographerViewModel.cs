using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApp.Domain.ViewModels.Photographer
{
    public class PhotographerViewModel
    {
        public int PhotographerId { get; set; }
        public string PhotographerName { get; set; }
        public string PhotographerEmail { get; set; }
        public short PhotographerWorkExperience { get; set; }

        public virtual ICollection<Domain.Entity.Publication> Publications { get; set; }
    }
}
