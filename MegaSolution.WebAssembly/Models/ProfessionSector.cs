using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.WebAssembly.Models
{
    public class ProfessionSector
    {
        public int ProfessionSectorId { get; set; }
        [Required]
        public string SectorName { get; set; }
        public virtual IList<Profession> Professions { get; set; }
    }
}
