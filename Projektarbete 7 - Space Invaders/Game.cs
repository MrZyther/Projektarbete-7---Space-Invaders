    class Game
{
    private const int EnemyMoveInterval = 5;
    private readonly Map map;
    private readonly Player player;
    private readonly Position playerPosition;
    private readonly Position[] formation;
    private readonly EnemyMovement enemyMovement;
    private readonly IEnemy[] enemies;
    private int turnsUntilEnemyMove = EnemyMoveInterval;

    public Game()
    {
        const int width = 20;
        const int height = 15;
        map = new Map(width, height);
        playerPosition = new Position(width / 2, height - 1, width, height);
        player = new Player(new PlayerMovement(), new PlayerCannon(), playerPosition, 3, 'P');

        formation = [new(5, 5, width, height), new(10, 5, width, height)];
        enemyMovement = new EnemyMovement(formation);

        enemies = new IEnemy[formation.Length];

        Enemy enemy = new Enemy(enemyMovement, new BlasterCannon(), formation[0], 1, 'E');
        Enemy enemy2 = new Enemy(enemyMovement, new RegularEnemyCannon(), formation[1], 1, 'E');

        enemies[0] = enemy;
        enemies[1] = enemy2;
    }

    internal void Start()
    {
        Console.Clear();
        while (!formation.Any(position => position.ReachedBottom()))
        {
            ConsoleKey? key = Console.KeyAvailable
                ? Console.ReadKey(intercept: true).Key
                : null;

            if (key == ConsoleKey.Escape)
            {
                return;
            }

            RunTurn(key);
            Draw();
            Thread.Sleep(100);
        }

        Console.WriteLine("Fienderna nådde nedersta raden.");
    }

    private void RunTurn(ConsoleKey? key)
    {
        player.Move(playerPosition, key);
        turnsUntilEnemyMove--;

        if (turnsUntilEnemyMove > 0)
        {
            return;
        }

        enemyMovement.PrepareStep();
        foreach (IEnemy enemy in enemies)
        {
            enemy.Advance();
        }

        enemyMovement.CompleteStep();
        turnsUntilEnemyMove = EnemyMoveInterval;
    }

    private void Draw()
    {
        Console.SetCursorPosition(0, 0);
        player.Draw(map);

        foreach (IEnemy enemy in enemies)
        {
            enemy.Draw(map);
        }

        map.CreateMap();
    }
}