using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaSolution.WASM.Contracts;
using MegaSolution.WASM.Models;


namespace MegaSolution.WASM.Pages.Users
{
    public class LoginBase:ComponentBase
    {
        [Inject]
        public IAuthenticationRepository _authRepo { get; set; }
        [Inject]
        public NavigationManager _navManager { get; set; }
        protected LoginModel Model = new LoginModel();
        protected bool response = true;
        protected async Task HandleLogin()
        {
            response = await _authRepo.Login(Model);

            if (response)
            {
                _navManager.NavigateTo("/");
            }

        }
    }
}
