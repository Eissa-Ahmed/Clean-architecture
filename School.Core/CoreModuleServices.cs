namespace School.Core;

public static class CoreModuleServices
{
    public static IServiceCollection ApplyCoreModuleServices(this IServiceCollection services)
    {
        //MediatR
        services.AddMediatR(opt => opt.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        //Auto Mapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        //Fluent Validation
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
