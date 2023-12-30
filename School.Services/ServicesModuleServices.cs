namespace School.Services;

public static class ServicesModuleServices
{
    public static IServiceCollection ApplyServicesModuleServices(this IServiceCollection services)
    {
        services.AddScoped<IStudentServices, StudentServices>();
        services.AddScoped<IDepartmentServices, DepartmentServices>();
        services.AddScoped<ISubjectServices, SubjectServices>();
        return services;
    }
}
