using MegaSolution.WASM.Contracts;
using MegaSolution.WASM.Models;
using MegaSolution.WASM.Static;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.WASM.Pages.Professions
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        public IProfessionRepository _repo { get; set; }

        protected IList<Profession> Model;

        protected async override Task OnInitializedAsync()
        {
            Model = await _repo.Get(EndPoints.ProfessionEndpoint);

        }
    }
}
