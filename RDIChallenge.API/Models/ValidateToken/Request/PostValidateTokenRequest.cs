using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDIChallenge.API.Models.ValidateToken.Request
{
    public class PostValidateTokenRequest
    {
        public int CostumerId { get; set; }

        public int CardId { get; set; }

        public int Token { get; set; }

        public int CVV { get; set; }

    }
}
