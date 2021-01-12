using MegaSolution.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Contracts
{
    public interface IArtistRepository:IRepositoryBase<Artist>
    {
        Task<IList<Artist>> Search(string keyword);
    }
}
