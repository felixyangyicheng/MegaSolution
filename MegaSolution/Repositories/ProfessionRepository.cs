using MegaSolution.Contracts;
using MegaSolution.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Repositories
{
    public class ProfessionRepository: IProfessionRepository
    {
        private readonly ApplicationDbContext _db;

        public ProfessionRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Profession entity)
        {
            await _db.Professions.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Profession entity)
        {
            _db.Professions.Remove(entity);
            return await Save();
        }

        public async Task<IList<Profession>> FindAll()
        {
            var professions = await _db.Professions
                .Include(q => q.ProfessionSector)
                .Include(q => q.Offers)
                .ToListAsync();
            return professions;
        }

        public async Task<Profession> FindById(int id)
        {
            var profession = await _db.Professions
               .Include(q => q.ProfessionSector)
                .Include(q => q.Offers)
                .FirstOrDefaultAsync(q => q.ProfessionId == id);
            return profession;
        }

        public async Task<bool> isExists(int id)
        {
            var isExists = await _db.Professions.AnyAsync(q => q.ProfessionId == id);
            return isExists;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Profession entity)
        {
            _db.Professions.Update(entity);
            return await Save();
        }
    }
}
