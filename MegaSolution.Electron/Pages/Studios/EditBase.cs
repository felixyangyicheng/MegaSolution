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
    public class EditBase : ComponentBase
    {
        [Inject]
        public IStudioRepository _repo { get; set; }
        [Inject]
        public NavigationManager _navManager { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }
        [Parameter]
        public string Id { get; set; }

        protected Studio Model = new Studio();
        protected bool isSuccess = true;
        protected override async Task OnInitializedAsync()
        {
            int id = Convert.ToInt32(Id);
            Model = await _repo.Get(EndPoints.StudioEndpoint, id);
        }

        protected async Task EditStudio()
        {
            isSuccess = await _repo.Update(EndPoints.StudioEndpoint, Model, Model.StudioId);
            if (isSuccess)
            {
                _toastService.ShowWarning("Studio mis à jour avec succès", "");
                BackToList();
            }

        }

        protected void BackToList()
        {
            _navManager.NavigateTo("/studios/");
        }
    }
}
