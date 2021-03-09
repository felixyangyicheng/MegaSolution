using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.WebAssembly.Models
{
    public class Offer
    {
        public int OfferId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime PublishDate { get; set; } = DateTime.Now;
        [Required]
        public int OfferDuration { get; set; }
        [Required]
        public int AvailablePlace { get; set; }
        [MaxLength(1000)]
        public string OfferDescription { get; set; }
        [MaxLength(1000)]
        public string ProfilDescription { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]

        public string OfferReference { get; set; }

        [Required]
        public int StudioId { get; set; }


        public virtual Studio Studio { get; set; }

        [Required]
        public int ProfessionId { get; set; }

        public virtual Profession Profession { get; set; }
    }
}
