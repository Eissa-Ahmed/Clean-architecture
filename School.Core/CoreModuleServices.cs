namespace School.Core;

public static class CoreModuleServices
{
    public static IServiceCollection ApplyCoreModuleServices(this IServiceCollection services)
    {
        //MediatR
        services.AddMediatR(opt => opt.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        //Auto Mapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
