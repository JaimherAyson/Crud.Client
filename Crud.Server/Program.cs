using Crud.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor",
        policy => policy.WithOrigins("https://localhost:7093") // Adjust based on your Blazor Server URL
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddScoped<ItemService>(); // Registers ItemService for dependency injection


var app = builder.Build();

app.UseCors("AllowBlazor");

// Enable middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
