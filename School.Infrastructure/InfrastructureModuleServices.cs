namespace School.Infrastructure;

public static class InfrastructureModuleServices
{
    public static IServiceCollection ApplyInfrastructureModuleServices(this IServiceCollection services, IConfiguration configuration)
    {
        //Configure Connection String
        services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }
}
