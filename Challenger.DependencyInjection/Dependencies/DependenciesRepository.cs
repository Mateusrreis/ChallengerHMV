using Challenger.Repository.Interfaces;
using Challenger.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Challenger.DependencyInjection
{
    public static class DependenciesRepository
    {
        public static void AddDependencyRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRepositoryDoctor, RepositoryMedico>();
        }
    }
}
