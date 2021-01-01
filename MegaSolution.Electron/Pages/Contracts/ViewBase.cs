using Blazored.Toast.Services;
using MegaSolution.Electron.Contracts;
using MegaSolution.Electron.Models;
using MegaSolution.Electron.Static;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Electron.Pages.Contracts
{
    public class ViewBase: ComponentBase
    {
        [Inject]
        public IContractRepository _repo { get; set; }
        [Inject]
        public NavigationManager _navManager { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected Contract Model = new Contract();

        protected override async Task OnInitializedAsync()
        {
            int id = Convert.ToInt32(Id);
            Model = await _repo.Get(EndPoints.ContractEndpoint, id);

        }

        protected void BackToList()
        {
            _navManager.NavigateTo("/contracts/");
        }

        protected void GoToEdit()
        {
            _navManager.NavigateTo($"/contracts/edit/{Model.ContractId}");
        }

        protected void GoToDelete()
        {
            _navManager.NavigateTo($"/contracts/delete/{Model.ContractId}");
        }
    }
}
