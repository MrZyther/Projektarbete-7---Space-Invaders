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

        IControls playerControl = player;
        List<Bullet> playerBullets = [];
        List<Bullet> enemyBullets = [];

        bool cursorVisible = Console.CursorVisible;
        Console.Clear();
        Console.CursorVisible = false;

        bool running = true;
        int frame = 0;

        while (running && player.IsAlive)
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
                enemyBullets.AddRange(wave.TryFireNext());
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
            Console.Write($"Wave: {wave.Number} | Health: {player.Health} | Move: arrows | Shoot: Space | Quit: Esc");
            Thread.Sleep(100);
            frame++;
        }

        Console.CursorVisible = cursorVisible;
        Console.WriteLine();
        if (!player.IsAlive)
        {
            Console.WriteLine("Game over.");
        }
    }
}