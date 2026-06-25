using dev.pitlor.SummerCamp.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

var app = builder.Build();
app.UseWebSockets();
app.UseHttpsRedirection();
app.MapHub<GamesHub>("/games");
app.MapHub<PlayHub>("/play");
app.Run();
