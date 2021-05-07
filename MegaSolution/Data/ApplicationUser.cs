using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Data
{
    public class ApplicationUser:IdentityUser
    {
        public virtual IList<Artist> Artists { get; set; }
        public virtual IList<DiffusionPartner> DiffusionPartners { get; set; }

        //public virtual ICollection<IdentityUser<string>> User { get; set; }
      
    }
}
