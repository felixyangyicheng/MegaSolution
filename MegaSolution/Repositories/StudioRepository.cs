using MegaSolution.Contracts;
using MegaSolution.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Repositories
{
    public class StudioRepository: IStudioRepository
    {
        private readonly ApplicationDbContext _db;

        public StudioRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return  _db.Studios.Count();
        }

        public async Task<bool> Create(Studio entity)
        {
            await _db.Studios.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Studio entity)
        {
            _db.Studios.Remove(entity);
            return await Save();
        }

        public async Task<IList<Studio>> FindAll()
        {
            var studios = await _db.Studios
               .Include(q => q.Offers)
               .ToListAsync();
            return studios;
        }

        public async Task<Studio> FindById(int id)
        {
            var studio = await _db.Studios
                 .Include(q => q.Offers)
                 .FirstOrDefaultAsync(q => q.StudioId == id);
            return studio;
        }

        public async Task<bool> isExists(int id)
        {
            var isExists = await _db.Studios.AnyAsync(q => q.StudioId == id);
            return isExists;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<IList<Studio>> Search(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return await _db.Studios.Where(a => a.StudioName.Contains(keyword)
                || a.Address.Contains(keyword)
                || a.City.Contains(keyword)).ToListAsync();
            }
            return await _db.Studios.ToListAsync();
        }

        public async Task<bool> Update(Studio entity)
        {
            _db.Studios.Update(entity);
            return await Save();
        }
    }
}
