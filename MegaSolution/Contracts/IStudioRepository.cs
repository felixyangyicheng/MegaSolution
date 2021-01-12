using MegaSolution.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Contracts
{
    public interface IStudioRepository:IRepositoryBase<Studio>
    {
        Task<IList<Studio>> Search(string keyword);

    }
}
