using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Data
{
    [Table("ContractTypes")]
    public class ContractType
    {
        public int ContractTypeId { get; set; }
        public string ContractTypeName { get; set; }
        public virtual IList<Contract> Contracts { get; set; }
    }
}
