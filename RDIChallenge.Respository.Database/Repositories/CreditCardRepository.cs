using RDIChallenge.Domain.Entities;
using RDIChallenge.Domain.Interfaces.Repository;
using RDIChallenge.Respository.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RDIChallenge.Respository.Database.Repositories
{
    public class CreditCardRepository : BaseRepository<CreditCard>, ICreditCardRepository
    {
        public CreditCardRepository(RDIChallengeContext context) : base(context) { }

        public async Task<CreditCard> FindById(int Id) =>
            await NoTracking().FirstOrDefaultAsync(x => x.Id == Id);


    }
}
