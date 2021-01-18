using Moq;
using NUnit.Framework;
using RDIChallenge.Domain.Entities;
using RDIChallenge.Domain.Interfaces.Services.CreditCardUseCases.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDIChallange.Service.Test.CreditCardTestCase.Flow
{
    [TestFixture]
    public class CreateCreditCardFlowTest
    {
        private Mock<ICreateCreditCardUseCase> createCreditCardUseCase { get; set; }

        [SetUp]
        public void SetUp()
        {
            createCreditCardUseCase = new Mock<ICreateCreditCardUseCase>();
        }


        private CreditCard createValidCard()
        {
            return CreditCard.Create(
                costumerID: It.IsAny<int>(),
                cardNumber: It.IsAny<long>(),
                cvv: It.IsAny<int>()
            );
        }

        [Test]
        public void CreateCreditCardShouldReturnSuscess()
        {
            CreditCard card = createValidCard();
            this.createCreditCardUseCase.Setup(x => x.Execute(card)).ReturnsAsync(card);
        }
    }
}
