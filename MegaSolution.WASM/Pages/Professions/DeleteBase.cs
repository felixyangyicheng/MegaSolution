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
    public class DeleteBase : ComponentBase
    {
        [Inject]
        public IProfessionRepository _repo { get; set; }
        [Inject]
        public NavigationManager _navManager { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }
        [Parameter]
        public string Id { get; set; }

        protected Profession Model = new Profession();
        protected bool isSuccess = true;

        protected override async Task OnInitializedAsync()
        {
            int id = Convert.ToInt32(Id);
            Model = await _repo.Get(EndPoints.ProfessionEndpoint, id);
        }

        protected async Task DeleteProfession()
        {

            isSuccess = await _repo.Delete(EndPoints.ProfessionEndpoint, Model.ProfessionId);
            if (isSuccess)
            {
                _toastService.ShowError("profession supprimée avec succès", "");
                BackToList();
            }

        }

        protected void BackToList()
        {
            _navManager.NavigateTo("/professions/");
        }
    }
}
