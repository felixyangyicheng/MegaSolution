using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.WebAssembly.Models
{
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
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Confirmer email")]
        [Compare("Email", ErrorMessage = "Le champs Email et le champs Confirmation doivent être identique.")]
        public string EmailConfirm { get; set; }
        [Required]
        public string StudioName { get; set; }
        [Required]
        [MaxLength(5)]
        public string PostCode { get; set; }
        [Required]
        public string City { get; set; }
        public virtual IList<Offer> Offers { get; set; }
    }
}
