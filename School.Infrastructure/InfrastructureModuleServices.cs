namespace School.Infrastructure;

public static class InfrastructureModuleServices
{
    public static IServiceCollection ApplyInfrastructureModuleServices(this IServiceCollection services, IConfiguration configuration)
    {
        //Configure Connection String
        services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<IDepartmentSubjectRepository, DepartmentSubjectRepository>();
        services.AddScoped<IStudentSubjectRepository, StudentSubjectRepository>();
        return services;
    }
}
