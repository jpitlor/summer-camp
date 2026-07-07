namespace dev.pitlor.SummerCamp.Services;

public class TasksService(GamesService gamesService) : IHostedService
{
    private Timer? _cleanGamesTimer;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var tomorrowAtMidnight = DateTime.Today.AddDays(1) - DateTime.Now;
        _cleanGamesTimer = new Timer(CleanGames, null, tomorrowAtMidnight, TimeSpan.FromDays(1));
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _cleanGamesTimer?.Dispose();
        return Task.CompletedTask;
    }

    private void CleanGames(object? state)
    {
        gamesService.CleanGames();
    }
}