using MegaSolution.WASM.Contracts;
using MegaSolution.WASM.Models;
using MegaSolution.WASM.Static;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.WASM.Pages.ProfessionSectors
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        public IProfessionSectorRepository _repo { get; set; }

        protected IList<ProfessionSector> Model;

        protected async override Task OnInitializedAsync()
        {
            Model = await _repo.Get(EndPoints.ProfessionSectorEndpoint);

        }
    }
}
