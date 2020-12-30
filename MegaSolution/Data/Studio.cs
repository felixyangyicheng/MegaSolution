using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Data
{
    [Table("Studios")]
    public class Studio
    {
        public int StudioId { get; set; }
        [Required]
        [StringLength(14, MinimumLength = 14)]
        public string Siret { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int AddressNumber { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string StudioName { get; set; }
        [Required]
        [MaxLength(10)]
        public string PostCode { get; set; }
        [Required]
        public string City { get; set; }
        public virtual IList<Offer> Offers { get; set; }
    }
}
