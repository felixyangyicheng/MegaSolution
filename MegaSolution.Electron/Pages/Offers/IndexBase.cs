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
    public class IndexBase : ComponentBase
    {
        [Inject]
        public IOfferRepository _repo { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }

        protected IList<Offer> Model;

        protected IList<Offer> SearchModel { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Model = await _repo.Get(EndPoints.OfferEndpoint);
        }

        protected async Task Filter()
        {

        }

        protected async Task Clear()
        {

        }

        public object selectedSearchValue { get; set; }
        protected void MySearchHandler(object newValue)
        {
            selectedSearchValue = newValue;
        }
    }
}
