using MegaSolution.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.DTOs
{
    public class ProfessionSectorDTO
    {
        public int ProfessionSectorId { get; set; }
       
        public string SectorName { get; set; }
        public virtual IList<Profession> Professions { get; set; }
    }
    public class ProfessionSectorCreateDTO
    {
   
        [Required]
        public string SectorName { get; set; }
     
    }
    public class ProfessionSectorUpdateDTO
    {
        public int ProfessionSectorId { get; set; }
        [Required]
        public string SectorName { get; set; }
     
    }
}
