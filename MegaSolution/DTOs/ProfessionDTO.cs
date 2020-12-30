using MegaSolution.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.DTOs
{
    public class ProfessionDTO
    {
        public int ProfessionId { get; set; }

        public string ProfessionName { get; set; }

        public int ProfessionSectorId { get; set; }

        public virtual ProfessionSector ProfessionSector { get; set; }
        public virtual IList<Offer> Offers { get; set; }
    }
    public class ProfessionCreateDTO
    {
  
        [Required]
        public string ProfessionName { get; set; }
        [Required]
        public int ProfessionSectorId { get; set; }
    }
    public class ProfessionUpdateDTO
    {
        public int ProfessionId { get; set; }
        [Required]
        public string ProfessionName { get; set; }
        [Required]
        public int ProfessionSectorId { get; set; }
    }
}
