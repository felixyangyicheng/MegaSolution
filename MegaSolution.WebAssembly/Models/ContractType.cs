using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.WebAssembly.Models
{
    public class ContractType
    {
        public int ContractTypeId { get; set; }
        public string ContractTypeName { get; set; }
        public virtual IList<Contract> Contracts { get; set; }
    }
}
