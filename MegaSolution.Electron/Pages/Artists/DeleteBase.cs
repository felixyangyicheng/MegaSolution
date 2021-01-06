using Blazored.Toast.Services;
using MegaSolution.Electron.Contracts;
using MegaSolution.Electron.Models;
using MegaSolution.Electron.Static;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Electron.Pages.Artists
{
    public class DeleteBase:ComponentBase
    {
        [Inject]
        public IArtistRepository _repo { get; set; }
        public IFileUpload _fileUpload { get; set; }
        [Inject]
        public NavigationManager _navManager { get; set; }
        [Inject]

        public IToastService _toastService { get; set; }
        [Parameter]
        public string Id { get; set; }

        protected Artist Model = new Artist();
        protected bool isSuccess = true;

        protected override async Task OnInitializedAsync()
        {
            int id = Convert.ToInt32(Id);
            Model = await _repo.Get(EndPoints.ArtistEndpoint, id);
        }

        protected async Task DeleteArtist()
        {
            if (Model.ProfilePhoto.Any())
            {
                _fileUpload.RemoveFile(Model.ProfilePhoto);
            }
            
            isSuccess = await _repo.Delete(EndPoints.ArtistEndpoint, Model.ArtistId);
            if (isSuccess)
            {
                _toastService.ShowError("Artiste supprimé", "");
                BackToList();
            }

        }

        protected void BackToList()
        {
            _navManager.NavigateTo("/artists/");
        }

    }
}
