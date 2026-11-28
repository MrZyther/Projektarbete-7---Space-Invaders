internal sealed class Game
{
    private const int Width = 20;
    private const int Height = 15;
    private readonly Map map = new(Width, Height);
    private readonly Scoreboard scoreboard = new();
    private readonly List<Bullet> playerBullets = [];
    private readonly Target playerTarget;
    private readonly Player player;
    private readonly Wave wave;

    internal Game()
    {
        Position start = new(Width / 2, Height - 1, Width, Height);
        player = new Player(new PlayerMovement(), new PlayerCannon(), start);
        playerTarget = new Target(player);
        wave = new Wave(Width, Height, scoreboard);
        wave.Spawn();
    }

    internal void PlayTurn(ConsoleKey? key)
    {
        player.Move(key);
        player.Act(key, playerBullets);
        playerBullets.RemoveAll(bullet => !bullet.Move()
            || wave.Intercept(bullet));
        wave.Advance();
        playerBullets.RemoveAll(wave.Intercept);
        wave.Fire(playerTarget);
        playerTarget.AdvanceShots();
    }

    internal string FinishTurn()
    {
        if (player.IsDestroyed())
        {
            return "Ditt skepp förstördes. Du förlorade!";
        }
        if (wave.HasInvaded())
        {
            return "Fienderna nådde nedersta raden. Du förlorade!";
        }
        if (wave.IsCleared())
        {
            playerBullets.Clear();
            playerTarget.ClearShots();
            wave.Spawn();
        }
        return "";
    }

    internal void Draw()
    {
        foreach (Bullet bullet in playerBullets)
        {
            bullet.Render(map);
        }
        playerTarget.DrawShots(map);
        wave.Draw(map);
        player.Draw(map);
        Console.SetCursorPosition(0, 0);
        map.CreateMap();
        scoreboard.Draw();
    }

    
}
