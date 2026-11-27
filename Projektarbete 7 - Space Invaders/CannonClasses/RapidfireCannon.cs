class RapidfireCannon : ICannon
{
    public Bullet[] TryFire(Position position, ConsoleKey? key)
    {
        Position front = position.Copy();
        if (front.TryMove(0, 1))
        {
            return [new Bullet(front, 0, 1), new Bullet(position, 0, 1)];
        }

        return [new Bullet(position, 0, 1)];
    }
}
