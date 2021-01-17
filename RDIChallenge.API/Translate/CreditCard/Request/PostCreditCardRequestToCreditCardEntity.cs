using RDIChallenge.API.Models.CreditCard.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RDIChallenge.Domain.Entities;

namespace RDIChallenge.API.Translate.CreditCard.Request
{
    public class PostCreditCardRequestToCreditCardEntity
    {
        public static RDIChallenge.Domain.Entities.CreditCard Translate(PostCreditCardRequest model) =>
            model != null ? RDIChallenge.Domain.Entities.CreditCard.Create(
                costumerID: model.CostumerId,
                cardNumber: model.CardNumber,
                cvv: model.CVV
            ) :
            RDIChallenge.Domain.Entities.CreditCard.Create();
    }
}
