using System;
using System.Collections.Generic;
using System.Text;

namespace RDIChallenge.Domain.Entities
{
    public class CreditCard: EntityBase
    {
        public int CostumerId { get; private set; }
        public long CardNumber { get; private set; }
        public int CVV { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public long Token { get; private set; }
        public static CreditCard Create(
                                        int costumerID,
                                        long cardNumber,
                                        int cvv) => new CreditCard
                                        {
                                            CostumerId = costumerID,
                                            CardNumber = cardNumber,
                                            CVV = cvv,
                                        };

        public static CreditCard Create() => new CreditCard();

        public void SetToken(long token) => Token = token;
        public void SetRegistrationDate(DateTime registrationDate) => RegistrationDate = registrationDate;
    }

}   
