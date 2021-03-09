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
    public class ViewBase: ComponentBase
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

        protected override async Task OnInitializedAsync()
        {
            int id = Convert.ToInt32(Id);
            Model = await _repo.Get(EndPoints.ProfessionEndpoint, id);

        }

        protected void BackToList()
        {
            _navManager.NavigateTo("/professions/");
        }

        protected void GoToEdit()
        {
            _navManager.NavigateTo($"/professions/edit/{Model.ProfessionId}");
        }

        protected void GoToDelete()
        {
            _navManager.NavigateTo($"/professions/delete/{Model.ProfessionId}");
        }
    }
}
