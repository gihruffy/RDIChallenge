using RDIChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RDIChallenge.Domain.Interfaces.Services.CreditCardUseCases.UseCase
{
    public interface IGetFindCreditCardUseCase
    {
        Task<CreditCard> Execute(int CardId);
    }
}
