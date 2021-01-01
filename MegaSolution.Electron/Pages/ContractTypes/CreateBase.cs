using Blazored.Toast.Services;
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
    public class CreateBase:ComponentBase
    {

        [Inject]

        public IContractTypeRepository _repo { get; set; }


        [Inject]
        public NavigationManager _navManager { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }

        protected ContractType Model = new ContractType();
        protected bool isSuccess = true;

        protected async Task CreateContractType()
        {
            isSuccess = await _repo.Create(EndPoints.ContractTypeEndpoint, Model);
            if (isSuccess)
            {
                _toastService.ShowSuccess("Type de contrat créé avec succès", "");
                BackToList();
            }
        }

        protected void BackToList()
        {
            _navManager.NavigateTo("/contracttypes/");
        }
    }
}
