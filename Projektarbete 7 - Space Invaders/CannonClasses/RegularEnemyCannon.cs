class RegularEnemyCannon : ICannon
{
    public Bullet[] TryFire(Position position, ConsoleKey? key)
    {
        return [new Bullet(position, 0, 1)];
    }

    public Bullet[] FireTick(Position position)
    {
        return [];
    }
}