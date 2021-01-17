using Microsoft.EntityFrameworkCore;
using RDIChallenge.Domain.Entities;

namespace RDIChallenge.Respository.Database.Context
{
    public class RDIChallengeContext: DbContext
    {

        public DbSet<CreditCard> CreditCard { get; set; }

        public RDIChallengeContext(DbContextOptions<RDIChallengeContext> options)
            :base(options)
        {

        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
      
    }
}
