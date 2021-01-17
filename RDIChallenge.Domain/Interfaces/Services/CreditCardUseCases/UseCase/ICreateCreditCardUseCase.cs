using RDIChallenge.Domain.Entities;
using System.Threading.Tasks;

namespace RDIChallenge.Domain.Interfaces.Services.CreditCardUseCases.UseCase
{
    public interface ICreateCreditCardUseCase
    {
        Task<CreditCard> Execute(CreditCard card);
    }
}
