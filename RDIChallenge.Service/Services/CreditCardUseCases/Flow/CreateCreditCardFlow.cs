using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDIChallenge.Domain.Entities;
using RDIChallenge.Domain.ExceptionHandler;
using RDIChallenge.Domain.Interfaces.Services.CreditCardTokenUseCases.UseCase;
using RDIChallenge.Domain.Interfaces.Services.CreditCardUseCases.Flow;
using RDIChallenge.Domain.Interfaces.Services.CreditCardUseCases.UseCase;


namespace RDIChallenge.Service.Services.CreditCardUseCases.Flow
{
    public class CreateCreditCardFlow: ICreateCreditCardFlow
    {

        private ICreateCreditCardUseCase _createCreditCardUseCase;
        private ICreateCreditCardTokenUseCase _creteCreditCardTokenUseCase;

        public CreateCreditCardFlow(
                                    ICreateCreditCardUseCase createCreditCardUseCase,
                                    ICreateCreditCardTokenUseCase creteCreditCardTokenUseCase
                                    )
        {
            _createCreditCardUseCase = createCreditCardUseCase;
            _creteCreditCardTokenUseCase = creteCreditCardTokenUseCase;
        }

        public async Task<CreditCard> Execute(CreditCard card)
        {
            try
            {
                long token = await _creteCreditCardTokenUseCase.Execute(card.CardNumber, card.CVV);
                card.SetToken(token);
                return await _createCreditCardUseCase.Execute(card);
            }
            catch (RDICustomException ex)
            {

                throw ex;
            }
            
        }
    }
}
