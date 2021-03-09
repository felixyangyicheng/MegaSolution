using Blazored.Toast.Services;
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
    public class EditBase : ComponentBase
    {
        [Inject]
        public IProfessionRepository _repo { get; set; }
        [Inject]

        public IProfessionSectorRepository _sectorRepo { get; set; }
        [Inject]
        public NavigationManager _navManager { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }
        [Parameter]
        public string Id { get; set; }

        protected Profession Model = new Profession();

        protected IList<ProfessionSector> ProfessionSectors;
        protected bool isSuccess = true;
        protected override async Task OnInitializedAsync()
        {
            int id = Convert.ToInt32(Id);
            Model = await _repo.Get(EndPoints.ProfessionEndpoint, id);
            ProfessionSectors = await _sectorRepo.Get(EndPoints.ProfessionSectorEndpoint);
        }

        protected async Task EditProfession()
        {
            isSuccess = await _repo.Update(EndPoints.ProfessionEndpoint, Model, Model.ProfessionId);
            if (isSuccess)
            {
                _toastService.ShowWarning("profession mise à jour avec succès", "");
                BackToList();
            }

        }

        protected void BackToList()
        {
            _navManager.NavigateTo("/professions/");
        }
    }
}
