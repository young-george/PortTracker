using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PortsTracker.Application;
using PortsTracker.Domain;

namespace PortsTracker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("PortsTracker"),
            ServiceLifetime.Transient);

        services.AddTransient<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddTransient<INotificationService, NotificationService>();
        return services;
    }
}