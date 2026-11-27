class RapidfireCannon : ICannon
{
    public Bullet[] TryFire(Position position, ConsoleKey? key)
    {
        return
        [
            new Bullet(position, 0, 1),
            new Bullet(position, 0, 2)
        ];
    }
}