using System.Threading.Tasks;
namespace RDIChallenge.Domain.Interfaces.Services.CreditCardTokenUseCases.UseCase
{
    public interface ICreateCreditCardTokenUseCase
    {
        Task<long> Execute(long cardNumber, int cvv);
    }
}
