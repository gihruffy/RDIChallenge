using RDIChallenge.Domain.Entities;
using RDIChallenge.Domain.Interfaces.Repository;
using RDIChallenge.Domain.Interfaces.Services.CreditCardUseCases.UseCase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RDIChallenge.Service.Services.CreditCardUseCases.UseCase
{
    public class GetFindCreditCardUseCase : IGetFindCreditCardUseCase
    {
        private ICreditCardRepository _creditCardRespository;
        public GetFindCreditCardUseCase(ICreditCardRepository creditCardRespository)
        {
            _creditCardRespository = creditCardRespository;
        }
        public async Task<CreditCard> Execute(int CardId)
        {
            return await _creditCardRespository.FindById(CardId);
        }
    }
}
