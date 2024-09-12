using TasteTrailUserManager.Infrastructure.Common.Assembly;

namespace TasteTrailUserManager.Api.Common.Extensions.ServiceCollection;
public static class AddMediatRMethod
{
    public static void AddMediatR(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(configuration => {
            Type typeInReferencedAssembly = typeof(InfrastructureAssemblyMaker);
            configuration.RegisterServicesFromAssembly( typeInReferencedAssembly.Assembly );
        });
    } 
}
