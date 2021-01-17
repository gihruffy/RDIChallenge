using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


namespace RDIChallenge.API.DependencyGroups
{
    public static class ApplicationServiceDependencies
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            CreditCardDependencies.AddDependencies(services);
            CreditCardTokenDependencies.AddDependencies(services);
        }

    }
}
