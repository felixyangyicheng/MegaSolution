using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.Toast.Services;

using MegaSolution.WASM.Contracts;
using MegaSolution.WASM.Models;
using MegaSolution.WASM.Static;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MegaSolution.WASM.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        public IJSRuntime _jSRuntime { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }
        [Inject]
        public IArtistRepository _artistRepository { get; set; }
        [Inject]
        public IStudioRepository _studioRepository { get; set; }
        [Inject]
        public IProfessionRepository _professionRepository { get; set; }
        [Inject]
        public IContractRepository _contractRepository { get; set; }
        [Inject]
        public IContractTypeRepository _typeRepository { get; set; }
        [Inject]
        public IProfessionSectorRepository _sectorRepository { get; set; }
        [Inject]
        public IDiffusionPartnerRepository _diffusionRepository { get; set; }
        [Inject]
        public IOfferRepository _offerRepository { get; set; }

    
        protected int TArtists;
        protected int TOffers;
        protected int TContrats;
        protected int TTypes;
        protected int TStudios;
        protected int TSectors;
        protected int TProfessions;
        protected int TDiffusions;

      
        protected async override Task OnInitializedAsync()
        {
            TArtists =await _artistRepository.Count(EndPoints.ArtistCountEndpoint);


            TOffers = await _offerRepository.Count(EndPoints.OfferCountEndpoint);
            

            TContrats = await _contractRepository.Count(EndPoints.ContractCountEndpoint);


            TTypes = await _typeRepository.Count(EndPoints.ContractTypeCountEndpoint);

        
 
            TStudios = await _studioRepository.Count(EndPoints.StudioCountEndpoint);


            TSectors = await _sectorRepository.Count(EndPoints.ProfessionSectorCountEndpoint);


            TProfessions = await _professionRepository.Count(EndPoints.ProfessionCountEndpoint);


            TDiffusions = await _diffusionRepository.Count(EndPoints.DiffusionPartnerCountEndpoint);

        }


        


    }
}
