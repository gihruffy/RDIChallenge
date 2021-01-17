using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RDIChallenge.API.Translate.CreditCard;
using RDIChallenge.API.Models.ValidateToken.Request;
using RDIChallenge.API.Models.ValidateToken.Response;
using RDIChallenge.Domain.Interfaces.Services.CreditCardTokenUseCases.Flow;
using Microsoft.AspNetCore.Http;
using RDIChallenge.API.Translate.ValidateToken.Request;
using RDIChallenge.API.Translate.ValidateToken.Response;

namespace RDIChallenge.API.Controllers
{
    public class ValidateTokenController : Controller
    {

        private IValidateCreditCardTokenFlow _validateCreditCardTokenFlow;

        public ValidateTokenController(IValidateCreditCardTokenFlow validateCreditCardTokenFlow)
        {
            _validateCreditCardTokenFlow = validateCreditCardTokenFlow;
        }
        [HttpPost("rdichallenge/v1/validateToken")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(PostValidateTokenResponse), StatusCodes.Status200OK)]
        [SwaggerOperation(operationId: "CreditCard_GET_Find")]

        public async Task<ActionResult> ValidateToken([FromBody] PostValidateTokenRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _validateCreditCardTokenFlow.Execute(PostValidateTokenRequestToValidateTokenEntity.Translate(model));
            var translateResponse = ValidateTokenToPostValidateTokenResponse.Translate(response);
            
            return Ok(translateResponse);

        }
    }
}
