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
    public class EditBase : ComponentBase
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
        [Parameter]
        public string Id { get; set; }

        protected Offer Model = new Offer();
        protected IList<Studio> Studios;
        protected IList<Profession> Professions;
        protected bool isSuccess = true;
        protected override async Task OnInitializedAsync()
        {
            int id = Convert.ToInt32(Id);
            Model = await _repo.Get(EndPoints.OfferEndpoint, id);
            Professions = await _professionRepo.Get(EndPoints.ProfessionEndpoint);
            Studios = await _studioRepo.Get(EndPoints.StudioEndpoint);
        }

        protected async Task EditOffer()
        {
            isSuccess = await _repo.Update(EndPoints.OfferEndpoint, Model, Model.OfferId);
            if (isSuccess)
            {
                _toastService.ShowWarning("Offre mise à jour avec succès", "");
                BackToList();
            }

        }

        protected void BackToList()
        {
            _navManager.NavigateTo("/offers/");
        }
    }
}
