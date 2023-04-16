using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicleToFleet;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetVehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
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

            services.AddScoped<RentVehiclePresenter>();
            services.AddScoped<IRentVehiclePresenter>(sp => sp.GetService<RentVehiclePresenter>());
            services.AddScoped<IOutputPortStandard<RentVehicleOutput>>(sp => sp.GetService<RentVehiclePresenter>());
            services.AddScoped<IRentVehicleOutportNotFound>(sp => sp.GetService<RentVehiclePresenter>());

            return services;
        }
    }
}
