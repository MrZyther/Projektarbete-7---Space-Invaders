class Game
{
    public void Start()
    {
        Map map = new Map(15, 15);
        Position start = new Position(7, 14, 15, 15);
        PlayerMovement movement = new PlayerMovement(input);
        List<Bullet> bullets = [];

        Console.Clear();
        Console.CursorVisible = false;
        while (input.ReadInput())
        {
            movement.Move(start);
            input.RunIfPressed(ConsoleKey.Spacebar,
            () => bullets.Add(new Bullet(start)));
            bullets.RemoveAll(bullet => !bullet.Move());
            Console.SetCursorPosition(0, 0);
            start.Draw(map, 'U');

            foreach (Bullet bullet in bullets)
            {
                bullet.Render(map);
            }

            map.CreateMap();
            Thread.Sleep(100);
        }
    }
}