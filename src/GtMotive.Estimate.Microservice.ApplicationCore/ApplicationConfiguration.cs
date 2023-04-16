using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.Api.UseCases.AddVehicleToFleet;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetVehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Implementations;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.ApplicationCore
{
    /// <summary>
    /// Adds Use Cases classes.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ApplicationConfiguration
    {
        /// <summary>
        /// Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IUseCase<AddVehicleToFleetInput>, AddVehicleToFleetUseCase>();
            services.AddTransient<IUseCase<GetVehiclesInput>, GetVehiclesUseCase>();

            return services;
        }
    }
}
