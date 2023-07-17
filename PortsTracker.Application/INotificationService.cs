namespace PortsTracker.Application;

public interface INotificationService
{ 
    Task Send(string phoneNumber, string message);
}