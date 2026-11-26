class RapidfireCannon : ICannon
{
    private bool secondShotPending;

    public Bullet[] TryFire(Position position, ConsoleKey? key)
    {
        if (secondShotPending)
        {
            return [];
        }

        secondShotPending = true;
        return [new Bullet(position, 0, 1)];
    }

    public Bullet[] FireTick(Position position)
    {
        if (!secondShotPending)
        {
            return [];
        }

        secondShotPending = false;
        return [new Bullet(position, 0, 1)];
    }
}