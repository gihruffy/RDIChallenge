using System;
using System.Collections.Generic;
using System.Text;

namespace RDIChallenge.Domain.Entities
{
    public class ValidateToken
    {
        public int CostumerId { get; private set; }

        public int CardId { get; private set; }

        public int Token { get; private set; }

        public int CVV { get; private set; }


        public static ValidateToken Create(int costumerId, int cardId, int token, int cvv) => new ValidateToken()
        {
            CostumerId = costumerId,
            CardId = cardId,
            Token = token,
            CVV = cvv
        };

        public static ValidateToken Create() => new ValidateToken() { };


    }
}
