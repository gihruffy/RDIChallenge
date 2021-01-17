using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDIChallenge.API.Models.ValidateToken.Response
{
    public class PostValidateTokenResponse
    {
        public bool Validated { get; set; }

        public static PostValidateTokenResponse Create(bool validated) => new PostValidateTokenResponse { Validated = validated };
    }
}
