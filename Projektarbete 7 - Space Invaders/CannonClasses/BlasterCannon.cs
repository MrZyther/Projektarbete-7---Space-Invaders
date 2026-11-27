internal sealed class BlasterCannon : ICannon
{
    public Bullet[] TryFire(Position position, ConsoleKey? key)
    {
        List<Bullet> shots = [];
        for (int dx = -1; dx <= 1; dx++)
        {
            if (position.Copy().TryMove(dx, 1))
            {
                shots.Add(new Bullet(position, dx, 1));
            }
        }

        return shots.ToArray();
    }
}
