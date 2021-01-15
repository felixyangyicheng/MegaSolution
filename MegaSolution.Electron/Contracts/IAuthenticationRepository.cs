using MegaSolution.Electron.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Electron.Contracts
{
    public interface IAuthenticationRepository
    {
        public Task<bool> PartnerRegister(RegistrationModel user);
        public Task<bool> AdminRegister(RegistrationModel user);
        public Task<bool> Register(RegistrationModel user);
        public Task<bool> Login(LoginModel user);
        public Task Logout();
    }
}
