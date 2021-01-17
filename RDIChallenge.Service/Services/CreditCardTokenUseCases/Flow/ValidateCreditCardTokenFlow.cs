using RDIChallenge.Domain.Entities;
using RDIChallenge.Domain.Interfaces.Services.CreditCardTokenUseCases.Flow;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RDIChallenge.Service.Services.CreditCardTokenUseCases.Flow
{
    public class ValidateCreditCardTokenFlow : IValidateCreditCardTokenFlow
    {

        public ValidateCreditCardTokenFlow()
        {

        }
        public Task<bool> Execute(ValidateToken validateToken)
        {
            return false;
        }
    }
}
