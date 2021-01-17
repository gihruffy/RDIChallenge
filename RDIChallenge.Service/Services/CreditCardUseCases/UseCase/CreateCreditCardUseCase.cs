using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RDIChallenge.Domain.Entities;
using RDIChallenge.Domain.Interfaces.Repository;
using RDIChallenge.Domain.Interfaces.Services;
using RDIChallenge.Domain.Interfaces.Services.CreditCardUseCases.Flow;
using RDIChallenge.Domain.Interfaces.Services.CreditCardUseCases.UseCase;


namespace RDIChallenge.Service.Services.CreditCardUseCases.UseCase
{
    public class CreateCreditCardUseCase : ICreateCreditCardUseCase
    {   
        private ICreditCardRepository _creditCardRespository;
        private readonly IUnitOfWork _unitOfWork;


        public CreateCreditCardUseCase(ICreditCardRepository creditCardRespository,
            IUnitOfWork unitOfWork)
        {
            _creditCardRespository = creditCardRespository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreditCard> Execute(CreditCard card)
        {
            card.SetRegistrationDate(DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc));
            var savedCard = _creditCardRespository.Save(card) ;
            await _unitOfWork.SaveChangesAsync();
            return card;
        }
    }
}
