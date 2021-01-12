using MegaSolution.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Contracts
{
    public interface IProfessionRepository:IRepositoryBase<Profession>
    {

        Task<IList<Profession>> Search(string keyword);

    }
}
