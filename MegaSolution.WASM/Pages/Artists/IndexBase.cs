using Blazored.Toast.Services;
using MegaSolution.WASM.Contracts;
using MegaSolution.WASM.Models;
using MegaSolution.WASM.Static;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.WASM.Pages.Artists
{
    public class IndexBase:ComponentBase
    {

        [Inject]
        public IArtistRepository _repo { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }

        protected IList<Artist> Model;

        protected int number;

        protected async override Task OnInitializedAsync()
        {
            Model = await _repo.Get(EndPoints.ArtistEndpoint);

            
        }
    }
}
