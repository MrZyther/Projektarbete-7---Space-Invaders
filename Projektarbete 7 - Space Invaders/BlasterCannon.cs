class BlasterCannon : ICannon
{
    public Bullet[] TryFire(Position position, ConsoleKey? key)
    {

        Position left = position.Copy();
        Position middle = position.Copy();
        Position right = position.Copy();

        return
        [
            new Bullet(left, -1, -1),
            new Bullet(middle, 0, -1),
            new Bullet(right, 1, -1)
        ];
    }

    public Bullet[] FireTick(Position position)
    {
        return [];
    }
}