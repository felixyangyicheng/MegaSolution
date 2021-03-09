using Blazored.Toast.Services;
using MegaSolution.WASM.Contracts;
using MegaSolution.WASM.Models;
using MegaSolution.WASM.Static;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.WASM.Pages.ContractTypes
{
    public class DeleteBase : ComponentBase
    {
        [Inject]
        public IContractTypeRepository _repo { get; set; }
        [Inject]
        public NavigationManager _navManager { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }
        [Parameter]
        public string Id { get; set; }

        public ContractType Model = new ContractType();
        protected bool isSuccess = true;
        protected override async Task OnInitializedAsync()
        {
            int id = Convert.ToInt32(Id);
            Model = await _repo.Get(EndPoints.ContractTypeEndpoint, id);
        }

        protected async Task DeleteContractType()
        {
            isSuccess = await _repo.Delete(EndPoints.ContractTypeEndpoint, Model.ContractTypeId);
            if (isSuccess)
            {
                _toastService.ShowError("type de contrat supprimé avec succès", "");
                BackToList();
            }
            else
            {
                _toastService.ShowError("impossible d'effectuer cette opération", "");
                BackToList();
            }
        }

        protected void BackToList()
        {
            _navManager.NavigateTo("/contracttypes/");
        }
    }
}
