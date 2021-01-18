using RDIChallenge.API.Models.CreditCard.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDIChallenge.API.Translate.CreditCard.Response
{
    public class PostCreditCardEntityToCreditCardResponse
    {
        public static PostCreditCardResponse Translate(Domain.Entities.CreditCard entity) =>
            entity != null ?
            PostCreditCardResponse.Create(
                cardId: entity.Id,
                registrationDate: entity.RegistrationDate,
                token: entity.Token
            ) : PostCreditCardResponse.Create();
    }
}
