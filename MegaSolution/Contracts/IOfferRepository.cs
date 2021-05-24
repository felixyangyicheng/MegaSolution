using MegaSolution.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Contracts
{
    public interface IOfferRepository:IRepositoryBase<Offer>
    {
        Task<IList<Offer>> Search(string keyword);
        Task<ArtistProfile> GetArtistProfileByUserId(string userId);
        Task CreateArtistProfile(ArtistProfile profile);
    }
}
