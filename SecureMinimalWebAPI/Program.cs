var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapGet("/data", (HttpContext httpContext) =>
{
    return $"Confidential data for {httpContext?.User?.Identity?.Name}";
}).WithName("GetSecureData");

app.Run();