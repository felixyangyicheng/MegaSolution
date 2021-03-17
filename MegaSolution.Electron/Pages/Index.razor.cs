using Blazored.Toast.Services;
using Blazorise.Charts;
using Blazorise.Charts.Streaming;
using MegaSolution.Electron.Contracts;
using MegaSolution.Electron.Static;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Electron.Pages
{

    public partial class Index : ComponentBase
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
        LineChart<LiveDataPoint> horizontalLineChart;
        LineChart<LiveDataPoint> verticalLineChart;
        BarChart<LiveDataPoint> horizontalBarChart;
        HorizontalBarChart<LiveDataPoint> verticalBarChart;

        Random random = new Random(DateTime.Now.Millisecond);

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
            TArtists = await _artistRepository.Count(EndPoints.ArtistCountEndpoint);
            TOffers = await _offerRepository.Count(EndPoints.OfferCountEndpoint);
            TContrats = await _contractRepository.Count(EndPoints.ContractCountEndpoint);
            TTypes = await _typeRepository.Count(EndPoints.ContractTypeCountEndpoint);
            TStudios = await _studioRepository.Count(EndPoints.StudioCountEndpoint);
            TSectors = await _sectorRepository.Count(EndPoints.ProfessionSectorCountEndpoint);
            TProfessions = await _professionRepository.Count(EndPoints.ProfessionCountEndpoint);
            TDiffusions = await _diffusionRepository.Count(EndPoints.DiffusionPartnerCountEndpoint);
        }

        string[] Labels = { "Red", "Blue", "Yellow", "Green", "Purple", "Orange" };
        List<string> backgroundColors = new List<string> { ChartColor.FromRgba(255, 99, 132, 0.5f), ChartColor.FromRgba(54, 162, 235, 0.5f), ChartColor.FromRgba(255, 206, 86, 0.5f), ChartColor.FromRgba(75, 192, 192, 0.5f), ChartColor.FromRgba(153, 102, 255, 0.5f), ChartColor.FromRgba(255, 159, 64, 0.5f) };
        List<string> borderColors = new List<string> { ChartColor.FromRgba(255, 99, 132, 1f), ChartColor.FromRgba(54, 162, 235, 1f), ChartColor.FromRgba(255, 206, 86, 1f), ChartColor.FromRgba(75, 192, 192, 1f), ChartColor.FromRgba(153, 102, 255, 1f), ChartColor.FromRgba(255, 159, 64, 1f) };

        public struct LiveDataPoint
        {
            public object X { get; set; }
            public object Y { get; set; }
        }

        object horizontalLineChartOptions = new
        {
            Title = new
            {
                Display = true,
                Text = "Nombre d'artistes inscrit en temps réel"
            },
            Scales = new
            {
                YAxes = new object[]
                {
                    new {
                        ScaleLabel = new {
                            Display = true, 
                            LabelString = "value",
                            
                        }
                    }
                }
            },
            Tooltips = new
            {
                Mode = "nearest",
                Intersect = false
            },
            Hover = new
            {
                Mode = "nearest",
                Intersect = false
            }
        };
        object verticalLineChartOptions = new
        {
            Title = new
            {
                Display = true,
                Text = "Total d'offres mises à jour "
            },
            Scales = new
            {
                XAxes = new object[]
                {
                    new {
                        Type = "linear",
                        Display = true,
                        ScaleLabel = new {
                            Display = true, LabelString = "value"
                        }
                    }
                }
            },
            Tooltips = new
            {
                Mode = "nearest",
                Intersect = false
            },
            Hover = new
            {
                Mode = "nearest",
                Intersect = false
            }
        };
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Task.WhenAll(
                    //HandleRedraw(horizontalLineChart, GetLineChartDataset1, GetLineChartDataset2),
                    //HandleRedraw(verticalLineChart, GetLineChartDataset1, GetLineChartDataset2)
                    HandleRedraw(horizontalLineChart, GetLineChartDataset1),
                    HandleRedraw(verticalLineChart, GetLineChartDataset2)
                    //HandleRedraw(horizontalBarChart, GetBarChartDataset1),
                    //HandleRedraw(verticalBarChart, GetBarChartDataset2)
                    );
            }
        }

        async Task HandleRedraw<TDataSet, TItem, TOptions, TModel>(BaseChart<TDataSet, TItem, TOptions, TModel> chart, params Func<TDataSet>[] getDataSets)
            where TDataSet : ChartDataset<TItem>
            where TOptions : ChartOptions
            where TModel : ChartModel
        {
            await chart.Clear();

            await chart.AddLabelsDatasetsAndUpdate(Labels, getDataSets.Select(x => x.Invoke()).ToArray());
        }

        async Task AddNewHorizontalLineDataSet()
        {
            var colorIndex = horizontalLineChart.Data.Datasets.Count % backgroundColors.Count;

            await horizontalLineChart.AddDatasetsAndUpdate(new LineChartDataset<LiveDataPoint>
            {
                Data = new List<LiveDataPoint>(),
                Label = $"Dataset {horizontalLineChart.Data.Datasets.Count + 1}",
                BackgroundColor = backgroundColors[colorIndex],
                BorderColor = borderColors[colorIndex],
                Fill = false,
                LineTension = 0,
            });
        }

        async Task AddNewHorizontalLineData()
        {
            foreach (var dataset in horizontalLineChart.Data.Datasets)
            {
                await horizontalLineChart.AddData(horizontalLineChart.Data.Datasets.IndexOf(dataset), new LiveDataPoint
                {
                    X = DateTime.Now,
                    Y = TArtists,
                });
            }

            await horizontalLineChart.Update();
        }

        async Task AddNewVerticalLineDataSet()
        {
            var colorIndex = verticalLineChart.Data.Datasets.Count % backgroundColors.Count;

            await verticalLineChart.AddDatasetsAndUpdate(new LineChartDataset<LiveDataPoint>
            {
                Data = new List<LiveDataPoint>(),
                Label = $"Dataset {verticalLineChart.Data.Datasets.Count + 1}",
                BackgroundColor = backgroundColors[colorIndex],
                BorderColor = borderColors[colorIndex],
                Fill = false,
                LineTension = 0,
            });
        }

        async Task AddNewVerticalLineData()
        {
            foreach (var dataset in verticalLineChart.Data.Datasets)
            {
                await verticalLineChart.AddData(verticalLineChart.Data.Datasets.IndexOf(dataset), new LiveDataPoint
                {
                    X = TArtists,
                    Y = DateTime.Now,
                });
            }

            await verticalLineChart.Update();
        }



        LineChartDataset<LiveDataPoint> GetLineChartDataset1()
        {
            return new LineChartDataset<LiveDataPoint>
            {
                Data = new List<LiveDataPoint>(),
                Label = "Nombres d'artistes",
                BackgroundColor = backgroundColors[0],
                BorderColor = borderColors[0],
                Fill = false,
                LineTension = 0,
                BorderDash = new List<int> { 8, 4 },
            };
        }

        LineChartDataset<LiveDataPoint> GetLineChartDataset2()
        {
            return new LineChartDataset<LiveDataPoint>
            {
                Data = new List<LiveDataPoint>(),
                Label = "Nombres d'offres",
                BackgroundColor = backgroundColors[1],
                BorderColor = borderColors[1],
                Fill = false,
                CubicInterpolationMode = "monotone",
            };
        }

        Task OnHorizontalLineRefreshed(ChartStreamingData<LiveDataPoint> data)
        {
            data.Value = new LiveDataPoint
            {
                X = DateTime.Now,
                Y = TArtists,
            };

            return Task.CompletedTask;
        }

        Task OnVerticalLineRefreshed(ChartStreamingData<LiveDataPoint> data)
        {
            data.Value = new LiveDataPoint
            {
                X = TOffers,
                Y = DateTime.Now,
            };

            return Task.CompletedTask;
        }


        double RandomScalingFactor()
        {
            return (random.NextDouble() > 0.5 ? 1.0 : -1.0) * Math.Round(random.NextDouble() * 100);
        }
    }
}
