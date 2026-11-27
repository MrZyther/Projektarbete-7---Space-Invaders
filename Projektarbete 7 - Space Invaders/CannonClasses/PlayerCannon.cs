class PlayerCannon : ICannon
{
    public Bullet[] TryFire(Position position, ConsoleKey? key)
    {
        if (key == ConsoleKey.Spacebar)
        {
            return [new Bullet(position)];
        }
        return [];
    }

    public Bullet[] FireTick(Position position)
    {
        return [];
    }
}