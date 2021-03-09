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
    public class DeleteBase: ComponentBase
    {
        [Inject]
        public IContractRepository _repo { get; set; }
    
        [Inject]
        public IFileUpload _fileUpload { get; set; }

        [Inject]
        public NavigationManager _navManager { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }
        [Parameter]
        public string Id { get; set; }

        protected Contract Model = new Contract();
        protected bool isSuccess = true;

        protected override async Task OnInitializedAsync()
        {
            int id = Convert.ToInt32(Id);
            Model = await _repo.Get(EndPoints.ContractEndpoint, id);
        }

        protected async Task DeleteContract()
        {
            _fileUpload.RemoveFile(Model.ContractPdfFile);
            isSuccess = await _repo.Delete(EndPoints.ContractEndpoint, Model.ContractId);
            if (isSuccess)
            {
                _toastService.ShowError("Contrat supprimé avec succès", "");
                BackToList();
            }

        }

        protected void BackToList()
        {
            _navManager.NavigateTo("/contracts/");
        }

    }
}
