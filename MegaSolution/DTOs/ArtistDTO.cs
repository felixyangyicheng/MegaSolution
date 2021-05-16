using MegaSolution.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.DTOs
{
    public class ArtistDTO
    {
        public int ArtistId { get; set; }
       
        public string FirstName { get; set; }

        public string LastName { get; set; }
   

        public string Email { get; set; }
        public string ProfilePhoto { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }


        public DateTime BirthDate { get; set; }
        public string ArtistName { get; set; }
        public Gender Gender { get; set; }
        public string CV { get; set; }
        public string ApplicationUserId { get; set; }//Added 16/05/2021 evo ArtistProfile
        public virtual ApplicationUser ApplicationUser { get; set; }//Added 16/05/2021 evo ArtistProfile

    }
    public class ArtistCreateDTO
    {
    
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]

        public string Email { get; set; }
        public string ProfilePhoto { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        public string ArtistName { get; set; }
        public Gender Gender { get; set; }
        public string CV { get; set; }

        public string ApplicationUserId { get; set; }//Added 16/05/2021 evo Obtain userId

    }
    public class ArtistUpdateDTO
    {
        public int ArtistId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]

        public string Email { get; set; }
        public string ProfilePhoto { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        public string ArtistName { get; set; }
        public Gender Gender { get; set; }
        public string CV { get; set; }
        public string ApplicationUserId { get; set; }//Added 16/05/2021 evo Obtain userId
    }
}
