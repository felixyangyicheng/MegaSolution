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

        protected string KeywordFilter = string.Empty;

        protected async override Task OnInitializedAsync()
        {
            Model = await _repo.Get(EndPoints.OfferEndpoint + $"search?keyword="+KeywordFilter);
        }

        protected async Task Filter()
        {
            OnInitializedAsync();
        }

        protected async Task Clear()
        {
            KeywordFilter = string.Empty;
            OnInitializedAsync();
        }

        public object selectedSearchValue { get; set; }
        protected void MySearchHandler(object newValue)
        {
            selectedSearchValue = newValue;
        }
    }
}
