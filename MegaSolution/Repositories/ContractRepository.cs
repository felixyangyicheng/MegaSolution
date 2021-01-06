using MegaSolution.Contracts;
using MegaSolution.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Repositories
{
    public class ContractRepository: IContractRepository
    {
        private readonly ApplicationDbContext _db;
        public ContractRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> Count()
        {
            return await _db.Contracts.CountAsync();
        }

        public async Task<bool> Create(Contract entity)
        {
            await _db.Contracts.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Contract entity)
        {
            _db.Contracts.Remove(entity);
            return await Save();
        }

        public async Task<IList<Contract>> FindAll()
        {
            var contracts = await _db.Contracts
                 .Include(c => c.ContractType)
                 .ToListAsync();
            return contracts;
        }

        public async Task<Contract> FindById(int id)
        {
            var contract = await _db.Contracts
                  .Include(c => c.ContractType)
                 .FirstOrDefaultAsync(c => c.ContractId == id);
            return contract;
        }

        public async Task<bool> isExists(int id)
        {
            var isExists = await _db.Contracts.AnyAsync(c => c.ContractId == id);
            return isExists;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Contract entity)
        {
            _db.Contracts.Update(entity);
            return await Save();
        }
    }
}
