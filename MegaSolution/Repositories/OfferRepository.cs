using MegaSolution.Contracts;
using MegaSolution.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Repositories
{
    public class OfferRepository: IOfferRepository
    {
        private readonly ApplicationDbContext _db;

        public OfferRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.Offers.Count();
        }

        public async Task<bool> Create(Offer entity)
        {
            await _db.Offers.AddAsync(entity);
            return await Save();
        }

        public async Task CreateArtistProfile(ArtistProfile profile)
        {
            await _db.Carts.AddAsync(profile);
            await Save();
        }

        public async Task<bool> Delete(Offer entity)
        {
            _db.Offers.Remove(entity);
            return await Save();
        }

        public async Task<IList<Offer>> FindAll()
        {
            var offers = await _db.Offers
                .Include(q => q.Profession)
                .Include(q => q.Studio)
                .ToListAsync();
            return offers;
        }

        public async Task<Offer> FindById(int id)
        {
            var offer = await _db.Offers
                .Include(q => q.Profession)
                .Include(q => q.Studio)
                .FirstOrDefaultAsync(q => q.OfferId == id);
            return offer;
        }

        public async  Task<ArtistProfile> GetArtistProfileByUserId(string userId)
        {
            return await _db.Carts
                  .Include(s => s.User)
                  .Include(s => s.LineOffers)
                  .ThenInclude(li => li.Offer)
                  .Where(s => s.UserId == userId)
                  .FirstOrDefaultAsync();
        }

        public async Task<bool> isExists(int id)
        {
            var isExists = await _db.Offers.AnyAsync(q => q.OfferId == id);
            return isExists;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<IList<Offer>> Search(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return await _db.Offers.Where(a => a.OfferDescription.Contains(keyword)
                || a.OfferReference.Contains(keyword)
                || a.Location.Contains(keyword)).ToListAsync();
            }
            return await _db.Offers.ToListAsync();
        }

        public async Task<bool> Update(Offer entity)
        {
            _db.Offers.Update(entity);
            return await Save();
        }
    }
}
