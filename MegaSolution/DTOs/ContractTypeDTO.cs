using MegaSolution.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.DTOs
{
    public class ContractTypeDTO
    {
        public int ContractTypeId { get; set; }
        public string ContractTypeName { get; set; }
        public virtual IList<Contract> Contracts { get; set; }
    }

    public class ContractTypeCreateDTO
    {
        [Required]
        public string ContractTypeName { get; set; }

    }
    public class ContractTypeUpdateDTO
    {
        public int ContractTypeId { get; set; }
        [Required]
        public string ContractTypeName { get; set; }

    }
}
