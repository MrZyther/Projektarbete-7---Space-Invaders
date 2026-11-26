class Game
{
    public void Start()
    {
        const int width = 28;
        const int height = 15;

        Map map = new Map(width, height);
        Position playerPosition = new Position(width / 2, height - 1, width, height);
        Player player = new Player(
            new PlayerMovement(),
            new PlayerCannon(),
            playerPosition,
            3,
            'U');

        const int enemyColumns = 8;
        const int enemyRows = 3;
        Position[] positions = new Position[enemyColumns * enemyRows];
        for (int row = 0; row < enemyRows; row++)
        {
            for (int column = 0; column < enemyColumns; column++)
            {
                int index = row * enemyColumns + column;
                positions[index] = new Position(3 + column * 3, 2 + row * 2, width, height);
            }
        }

        EnemyMovement enemyMovement = new EnemyMovement(positions);
        IEnemy[] enemies = new IEnemy[positions.Length];
        for (int row = 0; row < enemyRows; row++)
        {
            for (int column = 0; column < enemyColumns; column++)
            {
                int index = row * enemyColumns + column;
                if (row == 0)
                {
                    enemies[index] = new BasicEnemy(
                        enemyMovement, new RegularEnemyCannon(), positions[index], 1, 'b');
                }
                else if (row == 1)
                {
                    enemies[index] = new ArmoredEnemy(
                        enemyMovement, new BlasterCannon(), positions[index], 3, 'a');
                }
                else
                {
                    enemies[index] = new RapidfireEnemy(
                        enemyMovement, new RapidfireCannon(), positions[index], 2, 'x');
                }
            }
        }

        Wave wave = new Wave(enemies, enemyMovement);
        IControls playerControl = player;
        List<Bullet> playerBullets = [];
        List<Bullet> enemyBullets = [];

        bool cursorVisible = Console.CursorVisible;
        Console.Clear();
        Console.CursorVisible = false;

        bool running = true;
        bool enemiesAlive = true;
        int frame = 0;
        int nextEnemyToFire = 0;

        while (running && player.IsAlive && enemiesAlive)
        {
            ConsoleKey? key = Console.KeyAvailable
                ? Console.ReadKey(intercept: true).Key
                : null;

            if (key == ConsoleKey.Escape)
            {
                running = false;
                continue;
            }

            playerControl.Move(playerPosition, key);
            playerBullets.AddRange(player.TryFire(key));

            if (frame % 5 == 0)
            {
                wave.Advance();
            }

            if (frame % 20 == 0)
            {
                enemyBullets.AddRange(enemies[nextEnemyToFire].TryFire(null));
                nextEnemyToFire = (nextEnemyToFire + 1) % enemies.Length;
            }

            enemyBullets.AddRange(wave.FireTick());

            for (int i = playerBullets.Count - 1; i >= 0; i--)
            {
                Bullet bullet = playerBullets[i];
                bool removeBullet = !bullet.Move();

                if (!removeBullet && wave.TryHit(bullet, out Bullet[] response))
                {
                    removeBullet = true;
                    enemyBullets.AddRange(response);
                }

                if (removeBullet)
                {
                    playerBullets.RemoveAt(i);
                }
            }

            for (int i = enemyBullets.Count - 1; i >= 0; i--)
            {
                Bullet bullet = enemyBullets[i];
                if (!bullet.Move() || player.TryHit(bullet))
                {
                    enemyBullets.RemoveAt(i);
                }
            }

            enemiesAlive = false;
            foreach (IEnemy enemy in enemies)
            {
                if (enemy.IsAlive)
                {
                    enemiesAlive = true;
                    break;
                }
            }

            Console.SetCursorPosition(0, 0);
            wave.Draw(map);
            player.Draw(map);

            foreach (Bullet bullet in playerBullets)
            {
                bullet.Render(map);
            }

            foreach (Bullet bullet in enemyBullets)
            {
                bullet.Render(map);
            }

            map.CreateMap();
            Console.Write($"Health: {player.Health} | Move: arrows | Shoot: Space | Quit: Esc");
            Thread.Sleep(100);
            frame++;
        }

        Console.CursorVisible = cursorVisible;
        Console.WriteLine();
        if (!player.IsAlive)
        {
            Console.WriteLine("Game over.");
        }
        else if (!enemiesAlive)
        {
            Console.WriteLine("You win!");
        }
    }
}
