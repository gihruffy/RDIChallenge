using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RDIChallenge.Domain.Entities;

namespace RDIChallenge.Domain.Interfaces.Repository
{
    public interface ICreditCardRepository
    {
        CreditCard Save(CreditCard card);

        Task<CreditCard> FindById(int Id);
    }
}
