using MegaSolution.Contracts;
using MegaSolution.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Repositories
{
    public class ContractTypeRepository: IContractTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public ContractTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(ContractType entity)
        {
            await _db.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(ContractType entity)
        {
            _db.ContractTypes.Remove(entity);
            return await Save();
        }

        public async Task<IList<ContractType>> FindAll()
        {
            var contractTypes = await _db.ContractTypes
                 .Include(ct => ct.Contracts)
                .ToListAsync();
            return contractTypes;
        }

        public async Task<ContractType> FindById(int id)
        {
            var contractType = await _db.ContractTypes
                .Include(ct => ct.Contracts)
                .FirstOrDefaultAsync(ct=>ct.ContractTypeId==id);
            return contractType;
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.ContractTypes.AnyAsync(ct => ct.ContractTypeId == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(ContractType entity)
        {
            _db.ContractTypes.Update(entity);
            return await Save();
        }
    }
}
