using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDIChallenge.API.Models.CreditCard.Request
{
    public class PostCreditCardRequest
    {
        public int CostumerId { get; set; }
        public long CardNumber { get; set; }
        public int CVV { get; set; }
    }


    public class PostCreditCardRequestValidator : AbstractValidator<PostCreditCardRequest>
    {
        public PostCreditCardRequestValidator()
        {
            RuleFor(e => e.CostumerId)
                .NotEmpty().WithMessage("CostumerID must not be Empty")
                .NotNull().WithMessage("CostumerID must not be Null");

            RuleFor(e => e.CardNumber)
                .NotEmpty().WithMessage("CardNumber must not be Empty")
                .NotNull().WithMessage("CardNumber must not be Null");

            RuleFor(e => e.CardNumber.ToString())
                  .MaximumLength(16).WithMessage("CardNumber must be at max 16 characters lenght");

            RuleFor(e => e.CVV)
                    .NotEmpty().WithMessage("CVV must not be Empty")
                    .NotNull().WithMessage("CVV must not be Null");

            RuleFor(e => e.CVV.ToString())
               .MaximumLength(5).WithMessage("CVV must be at max 5 characters lenght");
        }
    }
}
