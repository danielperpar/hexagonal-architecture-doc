using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicleToFleet;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<AddVehicleToFleetPresenter>();
            services.AddScoped<IWebApiPresenter>(s => s.GetService<AddVehicleToFleetPresenter>());
            services.AddScoped<IOutputPortStandard<AddVehicleToFleetOutput>>(s => s.GetService<AddVehicleToFleetPresenter>());
            return services;
        }
    }
}
