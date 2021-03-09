using Blazored.Toast.Services;
using MegaSolution.WASM.Contracts;
using MegaSolution.WASM.Models;
using MegaSolution.WASM.Static;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.WASM.Pages.Contracts
{
    public class IndexBase: ComponentBase
    {
        [Inject]
        public IContractRepository _repo { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }

        protected IList<Contract> Model;

        protected async override Task OnInitializedAsync()
        {
            Model = await _repo.Get(EndPoints.ContractEndpoint);
        }
    }
}
