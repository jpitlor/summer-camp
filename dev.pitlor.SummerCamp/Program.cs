using dev.pitlor.SummerCamp.Hubs;
using dev.pitlor.SummerCamp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddTransient<GamesService>();
builder.Services.AddTransient<PlayService>();
builder.Services.AddControllers();

var app = builder.Build();
app.UseWebSockets();
app.UseHttpsRedirection();
app.MapHub<GamesHub>("/games");
app.MapHub<PlayHub>("/play");
app.MapControllers();
app.Run();
