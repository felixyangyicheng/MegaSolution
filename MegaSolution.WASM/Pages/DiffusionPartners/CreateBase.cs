using Blazored.Toast.Services;
using MegaSolution.WASM.Contracts;
using MegaSolution.WASM.Models;
using MegaSolution.WASM.Static;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.WASM.Pages.DiffusionPartners
{
    public class CreateBase : ComponentBase
    {
        [Inject]

        public IDiffusionPartnerRepository _repo { get; set; }


        [Inject]
        public NavigationManager _navManager { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }

        protected DiffusionPartner Model = new DiffusionPartner();
        protected bool isSuccess = true;

        protected async Task CreatePartner()
        {
            isSuccess = await _repo.Create(EndPoints.DiffusionPartnerEndpoint, Model);
            if (isSuccess)
            {
                _toastService.ShowSuccess("Partenaire créé avec succès", "");
                BackToList();
            }
        }

        protected void BackToList()
        {
            _navManager.NavigateTo("/diffusionpartners/");
        }
    }
}
