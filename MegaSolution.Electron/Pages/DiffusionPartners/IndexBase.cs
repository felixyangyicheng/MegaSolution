using MegaSolution.Electron.Contracts;
using MegaSolution.Electron.Models;
using MegaSolution.Electron.Static;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Electron.Pages.DiffusionPartners
{

    public class IndexBase : ComponentBase
    {
        [Inject]
        public IDiffusionPartnerRepository _repo { get; set; }

        protected IList<DiffusionPartner> Model;

        protected async override Task OnInitializedAsync()
        {
            Model = await _repo.Get(EndPoints.DiffusionPartnerEndpoint);

        }
    }
}
