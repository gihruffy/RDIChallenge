using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDIChallenge.API.Models.CreditCard.Response
{
    public class PostCreditCardResponse
    {
        public int CardId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public long Token { get; set; }


        public static PostCreditCardResponse Create(int cardId, DateTime registrationDate, long token) => 
            new PostCreditCardResponse 
            {
                CardId = cardId,
                RegistrationDate = registrationDate,
                Token = token
            };

        public static PostCreditCardResponse Create() => new PostCreditCardResponse() { };
    }
}
