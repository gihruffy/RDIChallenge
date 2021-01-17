using RDIChallenge.Domain.Entities;
using System.Threading.Tasks;

namespace RDIChallenge.Domain.Interfaces.Services.CreditCardUseCases.Flow
{
    public interface ICreateCreditCardFlow
    {
        Task<CreditCard> Execute(CreditCard card);
    }
}
