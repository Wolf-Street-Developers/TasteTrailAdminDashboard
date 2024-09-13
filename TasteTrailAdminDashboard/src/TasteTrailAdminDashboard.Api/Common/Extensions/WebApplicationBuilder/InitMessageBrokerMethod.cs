
namespace TasteTrailAdminDashboard.Api.Common.Extensions.WebApplicationBuilder;

using TasteTrailAdminDashboard.Infrastructure.Common.Options;
using Microsoft.AspNetCore.Builder;

public static class InitMessageBrokerMethod
{
    public static void InitMessageBroker(this WebApplicationBuilder builder)
    {
        var rabbitMqSection = builder.Configuration.GetSection("RabbitMq");
        builder.Services.Configure<RabbitMqOptions>(rabbitMqSection);
    }
}