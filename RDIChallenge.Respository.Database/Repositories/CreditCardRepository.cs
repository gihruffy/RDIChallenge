using RDIChallenge.Domain.Entities;
using RDIChallenge.Domain.Interfaces.Repository;
using RDIChallenge.Respository.Database.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RDIChallenge.Respository.Database.Repositories
{
    public class CreditCardRepository : BaseRepository<CreditCard>, ICreditCardRepository
    {
        public CreditCardRepository(RDIChallengeContext context) : base(context) { }

    }
}
