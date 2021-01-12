using MegaSolution.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Contracts
{
    public interface IContractRepository:IRepositoryBase<Contract>
    {
        Task<IList<Contract>> Search(string keyword);
    }
}
