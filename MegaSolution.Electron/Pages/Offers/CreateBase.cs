using Blazored.Toast.Services;
using MegaSolution.Electron.Contracts;
using MegaSolution.Electron.Models;
using MegaSolution.Electron.Static;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Electron.Pages.Offers
{
    public class CreateBase : ComponentBase
    {
        [Inject]

        public IOfferRepository _repo { get; set; }
        [Inject]
        public IProfessionRepository _professionRepo { get; set; }
        [Inject]
        public IStudioRepository _studioRepo { get; set; }

        [Inject]
        public NavigationManager _navManager { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }

        protected Offer Model = new Offer();
        protected IList<Studio> Studios;
        protected IList<Profession> Professions;
        protected bool isSuccess = true;

        protected override async Task OnInitializedAsync()
        {
            Studios = await _studioRepo.Get(EndPoints.StudioEndpoint);
            Professions = await _professionRepo.Get(EndPoints.ProfessionEndpoint);
        }
        protected async Task CreateOffer()
        {
            isSuccess = await _repo.Create(EndPoints.OfferEndpoint, Model);
            if (isSuccess)
            {
                _toastService.ShowSuccess("offre créée avec succès", "");
                BackToList();
            }
        }

        protected void BackToList()
        {
            _navManager.NavigateTo("/offers/");
        }
    }
}
