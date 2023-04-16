using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicleToFleet;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetVehicles;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<AddVehicleToFleetPresenter>();
            services.AddScoped<IAddVehicleToFleetPresenter>(sp => sp.GetService<AddVehicleToFleetPresenter>());
            services.AddScoped<IOutputPortStandard<AddVehicleToFleetOutput>>(sp => sp.GetService<AddVehicleToFleetPresenter>());

            services.AddScoped<GetVehiclesPresenter>();
            services.AddScoped<IGetVehiclesPresenter>(sp => sp.GetService<GetVehiclesPresenter>());
            services.AddScoped<IOutputPortStandard<GetVehiclesOutput>>(sp => sp.GetService<GetVehiclesPresenter>());
            services.AddScoped<IGetVehiclesOutputPortNotFound>(sp => sp.GetService<GetVehiclesPresenter>());

            return services;
        }
    }
}
