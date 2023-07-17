using MediatR;

namespace PortsTracker.Application.Notifications;

public class SendNotificationCommand : IRequest
{
    public string PhoneNumber { get; set; }
    public string Message { get; set; }
}

public class SendNotificationCommandHandler : IRequestHandler<SendNotificationCommand>
{
    private readonly INotificationService _notificationService;

    public SendNotificationCommandHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task<Unit> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
    {
        await _notificationService.Send(request.PhoneNumber, request.Message);

        return new Unit();
    }
}