﻿using Blazored.Toast.Services;
using MegaSolution.Electron.Contracts;
using MegaSolution.Electron.Models;
using MegaSolution.Electron.Static;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Electron.Pages.ProfessionSectors
{
    public class CreateBase : ComponentBase
    {
        [Inject]

        public IProfessionSectorRepository _repo { get; set; }


        [Inject]
        public NavigationManager _navManager { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }

        protected ProfessionSector Model = new ProfessionSector();
        protected bool isSuccess = true;

        protected async Task CreateSector()
        {
            isSuccess = await _repo.Create(EndPoints.ProfessionSectorEndpoint, Model);
            if (isSuccess)
            {
                _toastService.ShowSuccess("Secteur créé avec succès", "");
                BackToList();
            }
        }

        protected void BackToList()
        {
            _navManager.NavigateTo("/professionsectors/");
        }
    }
}
