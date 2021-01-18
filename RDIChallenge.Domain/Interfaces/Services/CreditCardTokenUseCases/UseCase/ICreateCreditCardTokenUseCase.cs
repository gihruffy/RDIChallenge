using RDIChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RDIChallenge.Domain.Interfaces.Services.CreditCardTokenUseCases.UseCase
{
    public interface ICreateCreditCardTokenUseCase
    {
        Task<long> Execute(long cardNumber, int cvv);
    }
}
