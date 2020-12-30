using MegaSolution.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.DTOs
{
    public class StudioDTO
    {
        public int StudioId { get; set; }
     
        public string Siret { get; set; }
     
        public string Address { get; set; }
    
        public int AddressNumber { get; set; }
     
        public string Phone { get; set; }
     
        public string Email { get; set; }
     
        public string StudioName { get; set; }
       
        public string PostCode { get; set; }
    
        public string City { get; set; }
        public virtual IList<Offer> Offers { get; set; }
    }

    public class StudioCreateDTO
    {
    
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
    
    }

    public class StudioUpdateDTO
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
      
    }
}
