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
    private readonly List<Bullet> playerBullets = [];
    private readonly List<Bullet> enemyBullets = [];
    private readonly Random random = new();
    



    public Game()
    {
        const int width = 20;
        const int height = 15;
        map = new Map(width, height);
        playerPosition = new Position(width / 2, height - 1, width, height);
        player = new Player(new PlayerMovement(), new PlayerCannon(), playerPosition, 3, 'P');

        formation =
        [
            new(5, 3, width, height),
            new(10, 3, width, height),
            new(15, 3, width, height),
            new(5, 5, width, height),
            new(10, 5, width, height),
            new(15, 5, width, height),
            new(5, 7, width, height),
            new(10, 7, width, height),
            new(15, 7, width, height)
        ];
        enemyMovement = new EnemyMovement(formation);

        enemies = new IEnemy[formation.Length];

        enemies[0] = new Enemy(enemyMovement, new RegularEnemyCannon(), formation[0], 1, 'E');
        enemies[1] = new Enemy(enemyMovement, new RegularEnemyCannon(), formation[1], 1, 'E');
        enemies[2] = new Enemy(enemyMovement, new RegularEnemyCannon(), formation[2], 1, 'E');

        enemies[3] = new ArmoredEnemy(enemyMovement, new BlasterCannon(), formation[3], 1, 'A');
        enemies[4] = new ArmoredEnemy(enemyMovement, new BlasterCannon(), formation[4], 1, 'A');
        enemies[5] = new ArmoredEnemy(enemyMovement, new BlasterCannon(), formation[5], 1, 'A');

        enemies[6] = new RapidfireEnemy(enemyMovement, new RapidfireCannon(), formation[6], 1, 'R');
        enemies[7] = new RapidfireEnemy(enemyMovement, new RapidfireCannon(), formation[7], 1, 'R');
        enemies[8] = new RapidfireEnemy(enemyMovement, new RapidfireCannon(), formation[8], 1, 'R');
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
            playerBullets.RemoveAll(bullet => enemies.Any(enemy => enemy.TryHit(bullet, out _)));
            Draw();
            Thread.Sleep(60);
        }

        Console.WriteLine("Fienderna nådde nedersta raden.");
    }

    private void RunTurn(ConsoleKey? key)
    {
        player.Move(playerPosition, key);

        playerBullets.AddRange(player.TryFire(key));
        playerBullets.RemoveAll(bullet => !bullet.Move());
        RemoveHitBullets();

        enemyBullets.RemoveAll(bullet => !bullet.Move());
        EnemyFire();
        
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
        RemoveHitBullets();
    }

    private void RemoveHitBullets()
    {
        foreach (Bullet bullet in playerBullets.ToArray())
        {
            foreach (IEnemy enemy in enemies)
            {
                if (enemy.TryHit(bullet, out _))
                {
                    playerBullets.Remove(bullet);
                    break;
                }
            }
        }
    }

    private void Draw()
    {
        Console.SetCursorPosition(0, 0);
        player.Draw(map);

        foreach (IEnemy enemy in enemies)
        {
            enemy.Draw(map);
        }
        foreach (Bullet bullet in playerBullets)
        {
            bullet.Render(map);
        }
        foreach (Bullet bullet in enemyBullets)
        {
            bullet.Render(map);
        }
        map.CreateMap();
    }

    private void EnemyFire()
    {

    foreach (IEnemy enemy in enemies)
    {
        if (enemy.IsAlive && random.Next(25) == 0)
        {
            enemyBullets.AddRange(enemy.TryFire(null));
        }
    }
    }
}

