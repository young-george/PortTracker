using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PortsTracker.Application.Movement.Commands.RegisterMovement;

namespace PortsTracker.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddTransient<IRequestHandler<RegisterMovementCommand>, RegisterMovementCommandHandler>();
        services.AddMediatR(typeof(RegisterMovementCommand));
        return services;
    }
}