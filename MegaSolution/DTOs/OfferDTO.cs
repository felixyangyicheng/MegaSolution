using MegaSolution.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.DTOs
{
    public class OfferDTO
    {
        public int OfferId { get; set; }
       
        public string Title { get; set; }
 
        public DateTime PublishDate { get; set; }
     
        public int OfferDuration { get; set; }
    
        public int AvailablePlace { get; set; }
      
        public string OfferDescription { get; set; }
        
        public string ProfilDescription { get; set; }
     
        public string Location { get; set; }
  

        public string OfferReference { get; set; }

      
        public int StudioId { get; set; }


        public virtual Studio Studio { get; set; }

       
        public int ProfessionId { get; set; }

        public virtual Profession Profession { get; set; }
    }
    public class OfferCreateDTO
    {
     
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
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


        [Required]
        public int ProfessionId { get; set; }

    }
    public class OfferUpdateDTO
    {
        public int OfferId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
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



        [Required]
        public int ProfessionId { get; set; }

 
    }
}
