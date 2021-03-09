using Blazored.LocalStorage;
using MegaSolution.WebAssembly.Contracts;
using MegaSolution.WebAssembly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MegaSolution.WebAssembly.Repositories
{
    public class ContractTypeRepository:BaseRepository<ContractType>, IContractTypeRepository
    {
        private readonly IHttpClientFactory _client;
        private readonly ILocalStorageService _localStorage;
        public ContractTypeRepository(IHttpClientFactory client,
            ILocalStorageService localStorage) : base(client, localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }
    }
}
