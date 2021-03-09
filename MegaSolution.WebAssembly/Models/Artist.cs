using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.WebAssembly.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Nom")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Prénom")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Confirmer email")]
        [Compare("Email", ErrorMessage = "Le champs Email et le champs Confirmation doivent être identique.")]
        public string EmailConfirm { get; set; }
        public string ProfilePhoto { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        [Required]
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public string ArtistName { get; set; }
        public Gender Gender { get; set; }
        public string CV { get; set; }
    }
}
