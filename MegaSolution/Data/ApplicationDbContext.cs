using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser> //Added 07/05/2021 evo ArtistProfile
    {
        public DbSet<ArtistProfile> Carts { get; set; }
        public DbSet<LineOffer> LineOffers { get; set; }
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
