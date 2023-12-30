using School.Core.MiddleWare;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ApplyInfrastructureModuleServices(builder.Configuration);
builder.Services.ApplyServicesModuleServices();
builder.Services.ApplyCoreModuleServices();
builder.Services.ApplyApiModuleServices(builder);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
