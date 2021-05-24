using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.DTOs
{
    public class LineOfferDTO
    {
        public int Id { get; set; }

        public int OfferId { get; set; }
        public OfferDTO Offer { get; set; }
        public Guid? ArtistProfileId { get; set; }
    }
}
