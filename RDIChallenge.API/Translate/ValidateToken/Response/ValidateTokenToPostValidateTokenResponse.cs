using RDIChallenge.API.Models.ValidateToken.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDIChallenge.API.Translate.ValidateToken.Response
{
    public class ValidateTokenToPostValidateTokenResponse
    {
        public static PostValidateTokenResponse Translate(bool isValid) => PostValidateTokenResponse.Create(isValid);
    }
}
