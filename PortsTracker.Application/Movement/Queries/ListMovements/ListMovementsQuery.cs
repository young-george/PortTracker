using MediatR;
using Microsoft.EntityFrameworkCore;
using PortsTracker.Domain;

namespace PortsTracker.Application.Movement.Queries.ListMovements;

public class ListMovementsQuery : IRequest<List<MovementDto>>
{
    
}

public class ListMovementsQueryHandler : IRequestHandler<ListMovementsQuery, List<MovementDto>>
{
    private readonly IApplicationDbContext _context;

    public ListMovementsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<MovementDto>> Handle(ListMovementsQuery request, CancellationToken cancellationToken)
    {
        var movements = await _context.Movements.ToListAsync(cancellationToken);

        return movements.Select(m => new MovementDto
        {
            Name = m.Name,
            Zone = m.Zone,
            MovementTime = m.MovementTime,
            PhoneNumber = m.PhoneNumber
        }).ToList();
    }
}