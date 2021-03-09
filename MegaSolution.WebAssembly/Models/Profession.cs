using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.WebAssembly.Models
{
    public class Profession
    {
        public int ProfessionId { get; set; }
        [Required]
        public string ProfessionName { get; set; }
        [Required]
        public int ProfessionSectorId { get; set; }

        public virtual ProfessionSector ProfessionSector { get; set; }
        public virtual IList<Offer> Offers { get; set; }
    }
}
