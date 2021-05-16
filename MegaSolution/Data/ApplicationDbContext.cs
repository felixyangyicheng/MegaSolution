using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<DiffusionPartner> DiffusionPartners { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<ProfessionSector> ProfessionSectors { get; set; }
        public DbSet<Studio> Studios { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


    }
}
