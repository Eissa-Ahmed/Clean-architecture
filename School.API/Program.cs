var builder = WebApplication.CreateBuilder(args);


builder.Services.ApplyInfrastructureModuleServices(builder.Configuration);
builder.Services.ApplyServicesModuleServices();
builder.Services.ApplyCoreModuleServices();
builder.Services.ApplyApiModuleServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
