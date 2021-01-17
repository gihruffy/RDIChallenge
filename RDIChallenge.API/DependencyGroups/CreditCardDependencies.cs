using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RDIChallenge.Domain.Interfaces.Services.CreditCardUseCases.UseCase;
using RDIChallenge.Domain.Interfaces.Services.CreditCardUseCases.Flow;
using RDIChallenge.Service.Services.CreditCardUseCases.UseCase;
using RDIChallenge.Service.Services.CreditCardUseCases.Flow;
using RDIChallenge.Domain.Interfaces.Repository;
using RDIChallenge.Respository.Database.Repositories;

namespace RDIChallenge.API.DependencyGroups
{
    public static class CreditCardDependencies
    {
        public static void AddDependencies(
             this IServiceCollection services)
        {
            services.AddScoped<ICreditCardRepository, CreditCardRepository>();
            services.AddScoped<ICreateCreditCardUseCase, CreateCreditCardUseCase>();
            services.AddScoped<ICreateCreditCardFlow, CreateCreditCardFlow>();
            
        }

    }
}
