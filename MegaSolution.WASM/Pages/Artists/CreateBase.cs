using Blazored.Toast.Services;
using MegaSolution.WASM.Contracts;
using MegaSolution.WASM.Models;
using MegaSolution.WASM.Static;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.WASM.Pages.Artists
{
    public class CreateBase: ComponentBase
    {
        [Inject]
        public IArtistRepository _repo { get; set; }
        [Inject]
        public IFileUpload _fileUpload { get; set; }
        [Inject]
        public NavigationManager _navManager { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }


        protected Artist Model = new Artist();
     
        protected IBrowserFile file;
        protected bool isSuccess = true;
        protected bool isInvalidFileType = false;
        protected string imageDataURL;
        protected Stream msFile;

      

        protected async Task HandleCreate()
        {
            if (!isInvalidFileType)
            {
                if (file != null)
                {
                    var ext = Path.GetExtension(file.Name);
                    var picId = Guid.NewGuid().ToString().Replace("-", "");
                    //var cvId = Guid.NewGuid().ToString().Replace("-", "");
                    var picName = $"{picId}{ext}";
                    //var cvName = $"{cvId}{ext}";
                    await _fileUpload.UploadFile(msFile, picName);

                    Model.ProfilePhoto = picName;
                }

                isSuccess = await _repo.Create(EndPoints.ArtistEndpoint, Model);
                if (isSuccess)
                {
                    _toastService.ShowSuccess("Le profil d'artist a été créé", "");
                    BackToList();
                }
            }
        }

        protected async Task HandleFileSelection(InputFileChangeEventArgs e)
        {
            file = e.File;
            if (file != null)
            {
                var ext = Path.GetExtension(file.Name);
                if (ext.Contains("jpg") || ext.Contains("png") || ext.Contains("jpeg"))
                {
                    msFile = file.OpenReadStream();

                    var resizedImageFile = await file.RequestImageFileAsync("image/png",
                100, 100);

                    var buffer = new byte[resizedImageFile.Size];
                    await resizedImageFile.OpenReadStream().ReadAsync(buffer);

                    var imageBase64Data = Convert.ToBase64String(buffer);
                    imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    isInvalidFileType = false;
                }
                else
                {
                    isInvalidFileType = true;
                    imageDataURL = string.Empty;
                }
            }
            else
            {
                isInvalidFileType = false;
            }
        }


        protected void BackToList()
        {
            _navManager.NavigateTo("/artists/");
        }
    }
}
