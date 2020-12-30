using Blazored.LocalStorage;
using MegaSolution.Electron.Contracts;
using MegaSolution.Electron.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MegaSolution.Electron.Repositories
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
