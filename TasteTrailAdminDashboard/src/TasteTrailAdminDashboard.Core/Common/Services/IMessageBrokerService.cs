namespace TasteTrailAdminDashboard.Core.Common.Services;

public interface IMessageBrokerService
{
    public Task PushAsync<T>(string destination, T obj);
}
