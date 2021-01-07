using Blazored.Toast.Services;
using MegaSolution.Electron.Contracts;
using MegaSolution.Electron.Models;
using MegaSolution.Electron.Static;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Electron.Pages.Studios
{
    public class CreateBase: ComponentBase
    {
        [Inject]

        public IStudioRepository _repo { get; set; }


        [Inject]
        public NavigationManager _navManager { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }

        protected Studio Model = new Studio();
        protected bool isSuccess = true;

        protected async Task CreateStudio()
        {
            isSuccess = await _repo.Create(EndPoints.StudioEndpoint, Model);
            if (isSuccess)
            {
                _toastService.ShowSuccess("Studio créé avec succès", "");
                BackToList();
            }
        }

        protected void BackToList()
        {
            _navManager.NavigateTo("/studios/");
        }
    }
}
