using MegaSolution.Contracts;
using MegaSolution.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Repositories
{
    public class DiffusionPartnerRepository: IDiffusionPartnerRepository
    {
        private readonly ApplicationDbContext _db;

        public DiffusionPartnerRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(DiffusionPartner entity)
        {
            await _db.DiffusionPartners.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(DiffusionPartner entity)
        {
            _db.DiffusionPartners.Remove(entity);
            return await Save();
        }

        public async Task<IList<DiffusionPartner>> FindAll()
        {
            var diffusionPartners = await _db.DiffusionPartners
                 .ToListAsync();
                
            return diffusionPartners;
        }

        public async Task<DiffusionPartner> FindById(int id)
        {
            var diffusionPartner = await _db.DiffusionPartners
               .FirstOrDefaultAsync(dp=>dp.DiffusionPartnerId==id);

            return diffusionPartner;
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.DiffusionPartners.AnyAsync(dp => dp.DiffusionPartnerId == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(DiffusionPartner entity)
        {
            _db.DiffusionPartners.Update(entity);
            return await Save();
        }
    }
}
