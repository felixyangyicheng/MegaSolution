using MegaSolution.Electron.Contracts;
using MegaSolution.Electron.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Electron.Pages.Users
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
