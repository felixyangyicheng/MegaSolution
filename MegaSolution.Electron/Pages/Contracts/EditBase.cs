using Blazored.Toast.Services;
using MegaSolution.Electron.Contracts;
using MegaSolution.Electron.Models;
using MegaSolution.Electron.Static;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Electron.Pages.Contracts
{
    public class EditBase: ComponentBase
    {
        [Inject]  
        public IContractRepository _repo { get; set; }
        [Inject]

        public IContractTypeRepository _typeRepo { get; set; }
        [Inject]
        public IFileUpload _fileUpload { get; set; }

        [Inject]
        public NavigationManager _navManager { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected Contract Model = new Contract();
        protected IList<ContractType> ContractTypes;
        protected IBrowserFile file;
        protected bool isSuccess = true;
        protected bool isInvalidFileType = false;
        protected bool isFileChanged = false;
        protected string imageDataURL;
        protected Stream msFile;

        protected override async Task OnInitializedAsync()
        {
            int id = Convert.ToInt32(Id);
            Model = await _repo.Get(EndPoints.ContractEndpoint, id);
            ContractTypes = await _typeRepo.Get(EndPoints.ContractTypeEndpoint);
        }

        protected async Task HandleUpdate()
        {
            if (!isInvalidFileType)
            {
                if (file != null)
                {
                    var ext = Path.GetExtension(file.Name);
                    var picId = Guid.NewGuid().ToString().Replace("-", "");
                    var picName = $"{picId}{ext}";

                    _fileUpload.RemoveFile(Model.ContractPdfFile);
                    await _fileUpload.UploadFile(msFile, picName);

                    Model.ContractPdfFile = picName;
                }
                else if (isFileChanged && file == null)
                {
                    _fileUpload.RemoveFile(Model.ContractPdfFile);
                    Model.ContractPdfFile = string.Empty;
                }

                isSuccess = await _repo.Update(EndPoints.ContractEndpoint, Model, Model.ContractId);
                if (isSuccess)
                {
                    _toastService.ShowWarning("Contract mis à jour avec succès", "");
                    BackToList();
                }
            }
        }

        protected async Task HandleFileSelection(InputFileChangeEventArgs e)
        {
            file = e.File;
            isFileChanged = true;
            if (file != null)
            {
                var ext = Path.GetExtension(file.Name);
                if (ext.Contains("jpg") || ext.Contains("png") || ext.Contains("jpeg") || ext.Contains("pdf"))
                {
                    msFile = file.OpenReadStream();

                    var resizedImageFile = await file.RequestImageFileAsync("image/png", 100, 100);

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
            _navManager.NavigateTo("/contracts/");
        }
    }
}
