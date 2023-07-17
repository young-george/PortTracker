using Microsoft.EntityFrameworkCore;
using PortsTracker.Domain;
using PortsTracker.Domain.Models;

namespace PortsTracker.Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Movement> Movements { get; set; }
    
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}