using Microsoft.AspNetCore.Identity;

namespace School.Infrastructure;

public static class InfrastructureModuleServices
{
    public static IServiceCollection ApplyInfrastructureModuleServices(this IServiceCollection services, IConfiguration configuration)
    {
        //Configure Connection String
        services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        //Configure Identity
        services.ConfigureIdentity();

        services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<IDepartmentSubjectRepository, DepartmentSubjectRepository>();
        services.AddScoped<IStudentSubjectRepository, StudentSubjectRepository>();
        return services;
    }

    private static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {

            // Default Password settings.
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 0;

            // Default User settings.
            options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;
        });
        return services;
    }
}
