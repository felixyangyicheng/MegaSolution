using MegaSolution.Contracts;
using MegaSolution.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Repositories
{

    public class ArtistRepository: IArtistRepository
    {
        private readonly ApplicationDbContext _db;
        public ArtistRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            
            return  _db.Artists.Count();
            
        }

        public async Task<bool> Create(Artist entity)
        {
            await _db.Artists.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Artist entity)
        {
            _db.Artists.Remove(entity);
            return await Save();
        }

        public async Task<IList<Artist>> FindAll()
        {
            var artists = await _db.Artists
              .ToListAsync();
            return artists;
        }

        public async Task<Artist> FindById(int id)
        {
            var artist = await _db.Artists
                 .FirstOrDefaultAsync(a => a.ArtistId==id);
            return artist;
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.Artists.AnyAsync(a => a.ArtistId == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<IList<Artist>> Search(string keyword)
        {
           
            if (!string.IsNullOrEmpty(keyword))
            {
               return await _db.Artists.Where(a => a.FirstName.Contains(keyword)
               ||a.LastName.Contains(keyword)
               ||a.ArtistName.Contains(keyword)).ToListAsync();
            }
            return await _db.Artists.ToListAsync();
        }

        public async Task<bool> Update(Artist entity)
        {
            _db.Artists.Update(entity);
            return await Save();
        }

        public async Task<IList<Artist>> FindArtistsByUserId(string userId) // 16/05/2021 Obtain UserId
        {
            return await _db.Artists
                .Include(s => s.ApplicationUser)
                .Where(s => s.ApplicationUserId == userId)
                .ToListAsync();
        }

     
    }
}
