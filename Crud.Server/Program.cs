using Crud.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ItemService>(builder.Configuration);
builder.Services.AddSingleton<ItemService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001/") });
builder.Services.AddScoped<ItemService>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();
