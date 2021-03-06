﻿using Blazored.Toast.Services;
using MegaSolution.Electron.Contracts;
using MegaSolution.Electron.Models;
using MegaSolution.Electron.Static;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Electron.Pages.Contracts
{
    public class IndexBase: ComponentBase
    {
        [Inject]
        public IContractRepository _repo { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }

        protected IList<Contract> Model;

        protected async override Task OnInitializedAsync()
        {
            Model = await _repo.Get(EndPoints.ContractEndpoint);
        }
    }
}
