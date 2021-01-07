using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.Toast.Services;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.PieChart;
using ChartJs.Blazor.Util;
using MegaSolution.Electron.Contracts;
using MegaSolution.Electron.Models;
using MegaSolution.Electron.Static;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MegaSolution.Electron.Pages
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

        protected PieConfig _config;
        protected override void OnInitialized()
        {
            _config = new PieConfig
            {
                Options = new PieOptions
                {
                    Responsive = true,
                    Title = new OptionsTitle
                    {
                        Display = true,
                        Text = "ChartJs.Blazor Pie Chart"
                    }
                }
            };

            foreach (string color in new[] { "Artistes", "Offres", "Contrats", "Types", "Studios", "Secteurs", "Professions", "Partenaires" })
            {
                _config.Data.Labels.Add(color);
            }

            PieDataset<int> dataset = new PieDataset<int>(new[] { TArtists, TOffers, TContrats, TTypes, TStudios, TSectors, TProfessions, TDiffusions })
            {
                BackgroundColor = new[]
                {
                    ColorUtil.ColorHexString(255, 99, 132), // Slice 1 aka "Red"
                    ColorUtil.ColorHexString(255, 205, 86), // Slice 2 aka "Yellow"
                    ColorUtil.ColorHexString(75, 192, 192), // Slice 3 aka "Green"
                    ColorUtil.ColorHexString(54, 162, 235), // Slice 4 aka "Blue"
                    ColorUtil.ColorHexString(255, 99, 132), // Slice 1 aka "Red"
                    ColorUtil.ColorHexString(255, 205, 86), // Slice 2 aka "Yellow"
                    ColorUtil.ColorHexString(75, 192, 192), // Slice 3 aka "Green"
                    ColorUtil.ColorHexString(54, 162, 235), // Slice 4 aka "Blue"
        }
            };

            if (TArtists!=0)
            {

                _config.Data.Datasets.Add(dataset);
            }
        }
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
