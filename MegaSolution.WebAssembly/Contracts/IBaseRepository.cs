using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.WebAssembly.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Get(string url, int id);
        Task<IList<T>> Get(string url);
        Task<bool> Create(string url, T obj);
        Task<bool> Update(string url, T obj, int id);
        Task<bool> Delete(string url, int id);

        Task<int> Count(string url);
    }
}
