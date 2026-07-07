using System.Text.Json.Serialization;
using dev.pitlor.SummerCamp.Hubs;
using dev.pitlor.SummerCamp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddSignalR()
    .AddJsonProtocol(options =>
    {
        options.PayloadSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddSingleton<GamesService>();
builder.Services.AddSingleton<PlayService>();
builder.Services.AddHostedService<EventsService>();
builder.Services.AddHostedService<TasksService>();
builder.Services.AddControllers();

var app = builder.Build();
app.UseWebSockets();
app.MapHub<GamesHub>("/games");
app.MapHub<PlayHub>("/play");
app.MapControllers();
app.Run();
