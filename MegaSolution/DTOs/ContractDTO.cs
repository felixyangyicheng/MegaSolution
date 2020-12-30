using MegaSolution.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.DTOs
{
    public class ContractDTO
    {
        public int ContractId { get; set; }
      
        public DateTime ContractBegins { get; set; }
   
        public int ContractDuration { get; set; }

        public string ContractReference { get; set; }
   
        public string ContractPdfFile { get; set; }
     
        public int ContractTypeId { get; set; }
        public virtual ContractTypeDTO ContractType { get; set; }
    }
    public class ContractCreateDTO
    {
        [Required]
        public DateTime ContractBegins { get; set; }
        [Required]
        public int ContractDuration { get; set; }
        [Required]
        [StringLength(5, MinimumLength = 2)]
        public string ContractReference { get; set; }
        [Required]
        public string ContractPdfFile { get; set; }
        [Required]
        public int ContractTypeId { get; set; }
 
    }
    public class ContractUpdateDTO
    {
        public int ContractId { get; set; }
        [Required]
        public DateTime ContractBegins { get; set; }
        [Required]
        public int ContractDuration { get; set; }
        [Required]
        [StringLength(5, MinimumLength = 2)]
        public string ContractReference { get; set; }
        [Required]
        public string ContractPdfFile { get; set; }
        [Required]
        public int ContractTypeId { get; set; }
  
    }
}
