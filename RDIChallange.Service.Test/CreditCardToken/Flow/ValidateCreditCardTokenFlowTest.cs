using Moq;
using RDIChallenge.Domain.Entities;
using RDIChallenge.Domain.Interfaces.Services.CreditCardTokenUseCases.Flow;
using RDIChallenge.Domain.Interfaces.Services.CreditCardTokenUseCases.UseCase;
using RDIChallenge.Domain.Interfaces.Services.CreditCardUseCases.UseCase;
using RDIChallenge.Service.Services.CreditCardTokenUseCases.Flow;
using Xunit;

namespace RDIChallange.Service.Test.CreditCardToken.Flow
{
    public class ValidateCreditCardTokenFlowTest
    {
        public Mock<IGetFindCreditCardUseCase> _getFindCreditCardUseCase { get; set; }
        public Mock<ICreateCreditCardTokenUseCase> _createCreditCardTokenUseCase { get; set; }
        private IValidateCreditCardTokenFlow _validateCreditCardTokenFlow;

        public ValidateCreditCardTokenFlowTest()
        {
            _getFindCreditCardUseCase = new Mock<IGetFindCreditCardUseCase>();
            _createCreditCardTokenUseCase = new Mock<ICreateCreditCardTokenUseCase>();
            _validateCreditCardTokenFlow = new ValidateCreditCardTokenFlow(_getFindCreditCardUseCase.Object, _createCreditCardTokenUseCase.Object);
        }

         
        [Fact]
        public void ValidateCreditCardTokenFlowTestShouldReturnSuccess()
        {
            long cardNumber = It.IsAny<long>();
            int cvv = It.IsAny<int>();
            long token  = It.IsAny<long>();
            RDIChallenge.Domain.Entities.CreditCard creditCard = RDIChallenge.Domain.Entities.CreditCard.Create();
            ValidateToken validateToken = ValidateToken.Create();

            this._getFindCreditCardUseCase
             .Setup(b => b.Execute(It.IsAny<int>()))
             .ReturnsAsync(creditCard);

            this._createCreditCardTokenUseCase
             .Setup(b => b.Execute(cardNumber, cvv))
             .ReturnsAsync(token);

            var exception = Record.ExceptionAsync(() => _validateCreditCardTokenFlow.Execute(validateToken)).Result;
            Assert.Null(exception);
        }

    }
}
