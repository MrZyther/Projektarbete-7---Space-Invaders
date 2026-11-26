class Game
{
    public void Start()
    {
        const int width = 15;
        const int height = 15;

        Map map = new Map(width, height);
        Position playerPosition = new Position(width / 2, height - 1, width, height);
        Player player = new Player(
            new PlayerMovement(),
            new PlayerCannon(),
            playerPosition,
            health: 1,
            symbol: 'U');
        List<Bullet> bullets = [];

        Console.Clear();
        Console.CursorVisible = false;


            bool running = true;
            while (running)
            {
                ConsoleKey? key = Console.KeyAvailable
                    ? Console.ReadKey(intercept: true).Key
                    : null;

                if (key == ConsoleKey.Escape)
                {
                    running = false;
                    continue;
                }

                player.Move(playerPosition, key);
                Bullet? bullet = player.TryFire(key);
                if (bullet is not null)
                {
                    bullets.Add(bullet);
                }

                bullets.RemoveAll(bullet => !bullet.Move());

                Console.SetCursorPosition(0, 0);
                player.Draw(map);
                foreach (Bullet activeBullet in bullets)
                {
                    activeBullet.Render(map);
                }

                map.CreateMap();
                Thread.Sleep(100);
            }
        }
    }

