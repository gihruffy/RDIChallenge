using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDIChallenge.Domain.Entities;
using RDIChallenge.Domain.Interfaces.Services.CreditCardTokenUseCases.UseCase;

namespace RDIChallenge.Service.Services.CreditCardTokenUseCases.UseCase
{
    public class CreateCreditCardTokenUseCase : ICreateCreditCardTokenUseCase
    {
        public async Task<long> Execute(CreditCard card)
        {
            string fullCardNumber = card.CardNumber.ToString();
            string lastFourDigitsCardNumber = fullCardNumber.Substring(fullCardNumber.Length - 4);
            int[] tokenArray = lastFourDigitsCardNumber.Select(s => Convert.ToInt32(s)).ToArray();
            
            for (int i = 0; i < card.CVV.ToString().Length; i++)
            {
                tokenArray = RightCircularRotation(tokenArray);
            }

            long token = Convert.ToInt64(String.Join("", tokenArray));

            return token;
        }

        private int[] RightCircularRotation(int[] tokenArray)
        {
            int temp;
            for (int j = 0; j < tokenArray.Length - 1; j++)
            {
                temp = tokenArray[0];
                tokenArray[0] = tokenArray[j + 1];
                tokenArray[j + 1] = temp;
            }

            return tokenArray;
        }

    }
}
