internal sealed class PlayerCannon : ICannon
{
    public Bullet[] TryFire(Position position, ConsoleKey? key)
    {
        if (key == ConsoleKey.Spacebar)
        {
            return [new Bullet(position)];
        }
        return [];
    }
}
