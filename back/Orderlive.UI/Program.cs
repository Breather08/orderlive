using Orderlive.UI;
using OrderLive.App;
using OrderLive.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCommon(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApp(typeof(Program));
builder.Services.AddTransient<OpenAIService>();

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
