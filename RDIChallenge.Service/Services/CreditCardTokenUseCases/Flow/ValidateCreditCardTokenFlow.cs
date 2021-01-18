using RDIChallenge.Domain.Entities;
using RDIChallenge.Domain.Interfaces.Services.CreditCardTokenUseCases.Flow;
using RDIChallenge.Domain.Interfaces.Services.CreditCardTokenUseCases.UseCase;
using RDIChallenge.Domain.Interfaces.Services.CreditCardUseCases.UseCase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RDIChallenge.Service.Services.CreditCardTokenUseCases.Flow
{
    public class ValidateCreditCardTokenFlow : IValidateCreditCardTokenFlow
    {
        IGetFindCreditCardUseCase _getFindCreditCardUseCase;
        ICreateCreditCardTokenUseCase _createCreditCardTokenUseCase;
        public ValidateCreditCardTokenFlow(
            IGetFindCreditCardUseCase getFindCreditCardUseCase, 
            ICreateCreditCardTokenUseCase createCreditCardTokenUseCase )
        {
            _getFindCreditCardUseCase = getFindCreditCardUseCase;
            _createCreditCardTokenUseCase = createCreditCardTokenUseCase;
        }
        public async Task<bool> Execute(ValidateToken validateToken)
        {
            bool isValid = false;
            CreditCard findCard = await _getFindCreditCardUseCase.Execute(validateToken.CardId);
            if(findCard != null && ValidateTokenDate(findCard.RegistrationDate))
            {
                if(CardBelongsToCostumer(findCard, validateToken))
                {
                    Console.WriteLine(findCard.CardNumber);
                    long newToken = await _createCreditCardTokenUseCase.Execute(findCard.CardNumber, validateToken.CVV);
                    isValid = IsTokenEquals(validateToken.Token, newToken);
                }
            }

            return isValid;            
        }

        private bool IsTokenEquals(long oldToken, long newToken) => oldToken == newToken;

        private bool CardBelongsToCostumer(CreditCard creditCard, ValidateToken validateToken) => creditCard.CostumerId == validateToken.CostumerId;

        private bool ValidateTokenDate(DateTime registrationDate)
        {
            DateTime dateNow = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            return dateNow < registrationDate.AddMinutes(30);
        }
       
    }
}
