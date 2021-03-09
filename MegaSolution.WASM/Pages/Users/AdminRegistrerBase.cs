using MegaSolution.WASM.Contracts;
using MegaSolution.WASM.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.WASM.Pages.Users
{
    public class AdminRegistrerBase : ComponentBase
    {

        [Inject]
        public IAuthenticationRepository _authRepo { get; set; }
        [Inject]
        public NavigationManager _navMan { get; set; }

        protected RegistrationModel Model = new RegistrationModel();
        protected bool response = true;

        protected async Task HandleRegistration()
        {
            response = await _authRepo.AdminRegister(Model);

            if (response)
            {
                _navMan.NavigateTo("/");
            }
        }
    }
}
