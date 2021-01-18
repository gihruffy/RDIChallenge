using RDIChallenge.Domain.Interfaces.Services.CreditCardTokenUseCases.UseCase;
using RDIChallenge.Service.Services.CreditCardTokenUseCases.UseCase;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RDIChallange.Service.Test.CreditCardToken.UseCase
{
    public class CreateCreditCardTokenUseCaseTest
    {
        private ICreateCreditCardTokenUseCase _createCreditCardTokenUseCase;

        public CreateCreditCardTokenUseCaseTest()
        {
            _createCreditCardTokenUseCase = new CreateCreditCardTokenUseCase();
        }



        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] { 5423244045904291, 135, 2914 },
            new object[] { 4556275980447948, 339, 9487 },
            new object[] { 30256186213643, 006, 4336 },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void CreateCreditCardTokenUseCaseSuccess(long cardNumber, int CVV, long expected)
        {
            // Act
            var result = _createCreditCardTokenUseCase.Execute(cardNumber, CVV).Result;

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
