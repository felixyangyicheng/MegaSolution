using MegaSolution.Electron.Contracts;
using MegaSolution.Electron.Models;
using MegaSolution.Electron.Static;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Electron.Pages.ContractTypes
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        public IContractTypeRepository _repo { get; set; }
        protected IList<ContractType> Model;

        protected async override Task OnInitializedAsync()
        {
            Model = await _repo.Get(EndPoints.ContractTypeEndpoint);

        }
    }
}
