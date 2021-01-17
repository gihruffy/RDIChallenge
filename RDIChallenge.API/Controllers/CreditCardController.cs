using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RDIChallenge.API.Models.CreditCard.Request;
using RDIChallenge.API.Translate.CreditCard.Request;
using RDIChallenge.API.Translate.CreditCard.Response;
using RDIChallenge.Domain.Interfaces.Services.CreditCardTokenUseCases.UseCase;
using RDIChallenge.Domain.Interfaces.Services.CreditCardUseCases.Flow;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDIChallenge.API.Controllers
{
    [ApiController]
    public class CreditCardController : Controller
    {
        private ICreateCreditCardTokenUseCase _createCreditCardTokenUseCase;
        private ICreateCreditCardFlow _createCreditCardFlow;

        public CreditCardController(ICreateCreditCardTokenUseCase createCreditCardTokenUseCase, ICreateCreditCardFlow createCreditCardFlow)
        {
            _createCreditCardTokenUseCase = createCreditCardTokenUseCase;
            _createCreditCardFlow = createCreditCardFlow;
    }


        [HttpGet("rdichallenge/v1/creditcard/find")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(List<GetCreditCardRequest>), StatusCodes.Status200OK)]
        [SwaggerOperation(operationId: "CreditCard_GET_Find")]
        public async Task<ActionResult> GetFind([FromQuery] GetCreditCardRequest model)
        {
            return Ok(model);
        }


        [HttpPost("rdichallenge/v1/creditcard")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(List<GetCreditCardRequest>), StatusCodes.Status200OK)]
        [SwaggerOperation(operationId: "CreditCard_GET_Find")]
        public async Task<ActionResult> Post([FromQuery] PostCreditCardRequest model)
        {
            var response = await _createCreditCardFlow.Execute(PostCreditCardRequestToCreditCardEntity.Translate(model));
            var translateResponse = PostCreditCardEntityToCreditCardResponse.Translate(response);

            return Ok(translateResponse);
        }




    }
}
