using MegaSolution.Contracts;
using MegaSolution.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Repositories
{
    public class ProfessionSectorRepository: IProfessionSectorRepository
    {
        private readonly ApplicationDbContext _db;

        public ProfessionSectorRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.ProfessionSectors.Count();
        }

        public async Task<bool> Create(ProfessionSector entity)
        {
            await _db.ProfessionSectors.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(ProfessionSector entity)
        {
            _db.ProfessionSectors.Remove(entity);
            return await Save();
        }

        public async Task<IList<ProfessionSector>> FindAll()
        {
            var professionSectors = await _db.ProfessionSectors
                 .Include(q => q.Professions)
                 .ToListAsync();
            return professionSectors;
        }

        public async Task<ProfessionSector> FindById(int id)
        {
            var professionSector = await _db.ProfessionSectors
                 .Include(q => q.Professions)
                 .FirstOrDefaultAsync(q => q.ProfessionSectorId == id);
            return professionSector;
        }

        public async Task<bool> isExists(int id)
        {
            var isExists = await _db.ProfessionSectors.AnyAsync(q => q.ProfessionSectorId == id);
            return isExists;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(ProfessionSector entity)
        {
            _db.ProfessionSectors.Update(entity);
            return await Save();
        }
    }
}
