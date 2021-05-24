using MegaSolution.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.DTOs
{
    public class ArtistProfileDTO
    {

        public Guid Id { get; set; }
        public string UserId { get; set; }
       // public ApplicationUser User { get; set; }

        public IList<LineOfferDTO> Offers { get; set; }
    }

    public class ArtistProfileCreateDTO
    {

    }

    public class ArtistProfileUpdateDTO
    {

    }
}
