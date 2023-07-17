using MediatR;
using Microsoft.EntityFrameworkCore;
using PortsTracker.Domain;

namespace PortsTracker.Application.Movement.Commands.RegisterMovement;

public class RegisterMovementCommand : IRequest
{
    public string Name { get; set; }
    public string Zone { get; set; }
    public DateTime MovementTime { get; set; }
    public string PhoneNumber { get; set; }
}

public class RegisterMovementCommandHandler : IRequestHandler<RegisterMovementCommand>
{
    private readonly IApplicationDbContext _context;

    public RegisterMovementCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(RegisterMovementCommand request, CancellationToken cancellationToken)
    {
        await _context.Movements.AddAsync(new Domain.Models.Movement
        {
            Name = request.Name,
            Zone = request.Zone,
            MovementTime = request.MovementTime,
            PhoneNumber = request.PhoneNumber
        }, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        
        return new Unit();
    }
}