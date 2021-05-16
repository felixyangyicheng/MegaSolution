using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Data
{
    public class ApplicationUser: IdentityUser //Added 07/05/2021 evo ArtistProfile
    {

        public virtual IList<Artist> Artists { get; set; }
        public virtual IList<DiffusionPartner> DiffusionPartners { get; set; }
      
    }
}
