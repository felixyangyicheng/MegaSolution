using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Data
{
  
    public class ArtistProfile
    {
        [Key]
        public Guid Id { get; set; }
        public string UserId  { get; set; }
        public ApplicationUser User { get; set; }

        public IList<LineOffer> LineOffers { get; set; }
    }
}
