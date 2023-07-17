using Microsoft.EntityFrameworkCore;
using PortsTracker.Domain.Models;

namespace PortsTracker.Domain;

public interface IApplicationDbContext
{ 
    DbSet<Movement> Movements { get; set; }

    Task SaveChangesAsync(CancellationToken cancellationToken);
}