using Microsoft.Extensions.DependencyInjection;
using RDIChallenge.Domain.Interfaces.Services.CreditCardTokenUseCases.Flow;
using RDIChallenge.Domain.Interfaces.Services.CreditCardTokenUseCases.UseCase;
using RDIChallenge.Service.Services.CreditCardTokenUseCases.Flow;
//using RDIChallenge.Domain.Interfaces.Services.CreditCardTokenUseCases.Flow;
using RDIChallenge.Service.Services.CreditCardTokenUseCases.UseCase;
//using RDIChallenge.Service.Services.CreditCardTokenUseCases.Flow;

namespace RDIChallenge.API.DependencyGroups
{
    public static class CreditCardTokenDependencies
    {
        public static void AddDependencies(
            this IServiceCollection services)
        {
            services.AddScoped<ICreateCreditCardTokenUseCase, CreateCreditCardTokenUseCase>();
            services.AddScoped<IValidateCreditCardTokenFlow, ValidateCreditCardTokenFlow>();
        }
    }
}

