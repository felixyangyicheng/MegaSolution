using Blazored.Toast.Services;
using MegaSolution.WASM.Contracts;
using MegaSolution.WASM.Models;
using MegaSolution.WASM.Static;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.WASM.Pages.Offers
{
    public class ViewBase : ComponentBase
    {
        [Inject]
        public IOfferRepository _repo { get; set; }
        [Inject]
        public NavigationManager _navManager { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected Offer Model = new Offer();


        protected override async Task OnInitializedAsync()
        {
            int id = Convert.ToInt32(Id);
            Model = await _repo.Get(EndPoints.OfferEndpoint, id);

        }


        protected void BackToList()
        {
            _navManager.NavigateTo("/offers/");
        }

        protected void GoToEdit()
        {
            _navManager.NavigateTo($"/offers/edit/{Model.OfferId}");
        }

        protected void GoToDelete()
        {
            _navManager.NavigateTo($"/offers/delete/{Model.OfferId}");
        }
    }
}
