using RDIChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RDIChallenge.Domain.Interfaces.Services.CreditCardTokenUseCases.Flow
{
    public interface IValidateCreditCardTokenFlow
    {
        Task<bool> Execute(ValidateToken validateToken);
    }
}
