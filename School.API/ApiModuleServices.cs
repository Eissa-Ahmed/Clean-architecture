namespace School.API;

public static class ApiModuleServices
{
    public static IServiceCollection ApplyApiModuleServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        // Add services to the container.
        services.AddControllers()
            .AddJsonOptions(option => option.JsonSerializerOptions.PropertyNamingPolicy = null);
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        //Mongo DB
        builder.Services.Configure<DbSettings>(builder.Configuration.GetSection(nameof(DbSettings)));
        builder.Services.AddSingleton<IDbSettings>(sp => sp.GetRequiredService<IOptions<DbSettings>>().Value);
        builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("DbSettings:ConnectionString")));

        return services;
    }

}
