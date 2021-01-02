using Blazored.Toast.Services;
using MegaSolution.Electron.Contracts;
using MegaSolution.Electron.Models;
using MegaSolution.Electron.Static;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Electron.Pages.DiffusionPartners
{
    public class EditBase : ComponentBase
    {
        [Inject]
        public IDiffusionPartnerRepository _repo { get; set; }
        [Inject]
        public NavigationManager _navManager { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }
        [Parameter]
        public string Id { get; set; }

        protected DiffusionPartner Model = new DiffusionPartner();
        protected bool isSuccess = true;
        protected override async Task OnInitializedAsync()
        {
            int id = Convert.ToInt32(Id);
            Model = await _repo.Get(EndPoints.DiffusionPartnerEndpoint, id);
        }

        protected async Task EditPartner()
        {
            isSuccess = await _repo.Update(EndPoints.DiffusionPartnerEndpoint, Model, Model.DiffusionPartnerId);
            if (isSuccess)
            {
                _toastService.ShowWarning("Partenaire mis à jour avec succès", "");
                BackToList();
            }

        }

        protected void BackToList()
        {
            _navManager.NavigateTo("/diffusionpartners/");
        }
    }
}
