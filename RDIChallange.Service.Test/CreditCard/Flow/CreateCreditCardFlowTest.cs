using Moq;
using RDIChallenge.Domain.Interfaces.Services.CreditCardTokenUseCases.UseCase;
using RDIChallenge.Domain.Interfaces.Services.CreditCardUseCases.Flow;
using RDIChallenge.Domain.Interfaces.Services.CreditCardUseCases.UseCase;
using RDIChallenge.Service.Services.CreditCardUseCases.Flow;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RDIChallange.Service.Test.CreditCard.Flow
{
    public class CreateCreditCardFlowTest
    {
        private Mock<ICreateCreditCardUseCase> _createCreditCardUseCase { get; set; }
        private Mock<RDIChallenge.Domain.Interfaces.Services.CreditCardTokenUseCases.UseCase.ICreateCreditCardTokenUseCase> _creteCreditCardTokenUseCase { get; set; }
        private ICreateCreditCardFlow _createCreditCardFlow;


        public CreateCreditCardFlowTest()
        {
            _createCreditCardUseCase = new Mock<ICreateCreditCardUseCase>();
            _creteCreditCardTokenUseCase = new Mock<RDIChallenge.Domain.Interfaces.Services.CreditCardTokenUseCases.UseCase.ICreateCreditCardTokenUseCase>();
            _createCreditCardFlow = new CreateCreditCardFlow(_createCreditCardUseCase.Object, _creteCreditCardTokenUseCase.Object);
        }

        private RDIChallenge.Domain.Entities.CreditCard MockCard()
        {
            return RDIChallenge.Domain.Entities.CreditCard.Create(
                costumerID: 1,
                cardNumber: 6565863686,
                cvv: 240
            );
        }
        private RDIChallenge.Domain.Entities.CreditCard MockInvalidCard()
        {
            return RDIChallenge.Domain.Entities.CreditCard.Create(
                costumerID: It.IsAny<int>(),
                cardNumber: It.IsAny<long>(),
                cvv: 240
            );
        }


        [Fact]
        public void CreateCreditCardFlowShouldReturnSuccess()
        {

            RDIChallenge.Domain.Entities.CreditCard creditCard = MockCard();
            
            this._createCreditCardUseCase
                .Setup(b => b.Execute(creditCard))
                .ReturnsAsync(creditCard);

            this._creteCreditCardTokenUseCase.Setup(x => x.Execute(creditCard.CardNumber, creditCard.CVV)).ReturnsAsync(It.IsAny<long>());

            var exception = Record.ExceptionAsync(() => _createCreditCardFlow.Execute(creditCard)).Result;
            
            Assert.Null(exception);
        }
    }
}
