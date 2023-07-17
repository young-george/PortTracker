using MediatR;
using Microsoft.AspNetCore.Mvc;
using PortsTracker.Application.Movement.Commands.RegisterMovement;
using PortsTracker.Application.Movement.Queries.ListMovements;

namespace PortsTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<List<MovementDto>> ListMovements()
        {
            return await _mediator.Send(new ListMovementsQuery());
        }

        [HttpPost()]
        public async Task RegisterMovement([FromBody] RegisterMovementCommand movement)
        {
            await _mediator.Send(movement);
        }
    }
}
