using Blazored.Toast.Services;
using MegaSolution.Electron.Contracts;
using MegaSolution.Electron.Models;
using MegaSolution.Electron.Static;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Electron.Pages.Professions
{
    public class CreateBase:ComponentBase
    {
        [Inject]

        public IProfessionRepository _repo { get; set; }
        [Inject]

        public IProfessionSectorRepository _sectorRepo { get; set; }


        [Inject]
        public NavigationManager _navManager { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }

        protected IList<ProfessionSector> ProfessionSectors;
        protected Profession Model = new Profession();
        protected bool isSuccess = true;

        protected override async Task OnInitializedAsync()
        {
            ProfessionSectors = await _sectorRepo.Get(EndPoints.ProfessionSectorEndpoint);
        }

        protected async Task CreateProfession()
        {
            isSuccess = await _repo.Create(EndPoints.ProfessionEndpoint, Model);
            if (isSuccess)
            {
                _toastService.ShowSuccess("Profession créé avec succès", "");
                BackToList();
            }
        }

        protected void BackToList()
        {
            _navManager.NavigateTo("/professions/");
        }
    }
}
