class Game
{
    private const int Width = 20;
    private const int Height = 15;
    private readonly Map map = new(Width, Height);
    private readonly Scoreboard scoreboard = new();
    private readonly List<Bullet> playerBullets = [];
    private readonly List<Bullet> enemyBullets = [];
    private readonly Player player;
    private readonly Wave wave;

    public Game()
    {
        Position start = new(Width / 2, Height - 1, Width, Height);
        player = new Player(new PlayerMovement(), new PlayerCannon(), start);
        wave = new Wave(Width, Height, scoreboard);
    }

    public string PlayTurn(ConsoleKey? key)
    {
        player.Act(key, playerBullets);
        playerBullets.RemoveAll(bullet => !bullet.Move());
        wave.TakeHits(playerBullets);
        wave.Advance();
        wave.TakeHits(playerBullets);
        wave.Fire(enemyBullets);
        if (!player.Survives(enemyBullets))
        {
            return "Ditt skepp förstördes. Du förlorade!";
        }

        return wave.CheckOutcome();
    }

    public void Draw()
    {
        foreach (Bullet bullet in playerBullets.Concat(enemyBullets))
        {
            bullet.Render(map);
        }

        wave.Draw(map);
        player.Draw(map);
        Console.SetCursorPosition(0, 0);
        map.CreateMap();
        scoreboard.Draw();
    }
}
