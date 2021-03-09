using MegaSolution.WASM.Contracts;
using MegaSolution.WASM.Models;
using MegaSolution.WASM.Static;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.WASM.Pages.Studios
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        public IStudioRepository _repo { get; set; }

        protected IList<Studio> Model;

        protected async override Task OnInitializedAsync()
        {
            Model = await _repo.Get(EndPoints.StudioEndpoint);

        }
    }
}
