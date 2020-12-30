using AutoMapper;
using MegaSolution.Data;
using MegaSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Mappings
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<Artist, ArtistDTO>().ReverseMap();
            CreateMap<Artist, ArtistCreateDTO>().ReverseMap();
            CreateMap<Artist, ArtistUpdateDTO>().ReverseMap();

            CreateMap<Contract, ContractDTO>().ReverseMap();
            CreateMap<Contract, ContractCreateDTO>().ReverseMap();
            CreateMap<Contract, ContractUpdateDTO>().ReverseMap();

            CreateMap<ContractType, ContractTypeDTO>().ReverseMap();
            CreateMap<ContractType, ContractTypeCreateDTO>().ReverseMap();
            CreateMap<ContractType, ContractTypeUpdateDTO>().ReverseMap();

            CreateMap<DiffusionPartner, DiffusionPartnerDTO>().ReverseMap();
            CreateMap<DiffusionPartner, DiffusionPartnerCreateDTO>().ReverseMap();
            CreateMap<DiffusionPartner, DiffusionPartnerUpdateDTO>().ReverseMap();

            CreateMap<Offer, OfferDTO>().ReverseMap();
            CreateMap<Offer, OfferCreateDTO>().ReverseMap();
            CreateMap<Offer, OfferUpdateDTO>().ReverseMap();

            CreateMap<Profession, ProfessionDTO>().ReverseMap();
            CreateMap<Profession, ProfessionCreateDTO>().ReverseMap();
            CreateMap<Profession, ProfessionUpdateDTO>().ReverseMap();

            CreateMap<ProfessionSector, ProfessionSectorDTO>().ReverseMap();
            CreateMap<ProfessionSector, ProfessionSectorCreateDTO>().ReverseMap();
            CreateMap<ProfessionSector, ProfessionSectorUpdateDTO>().ReverseMap();

            CreateMap<Studio, StudioDTO>().ReverseMap();
            CreateMap<Studio, StudioCreateDTO>().ReverseMap();
            CreateMap<Studio, StudioUpdateDTO>().ReverseMap();
        }
    }
}
