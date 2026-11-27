interface ICannon
{
    Bullet[] TryFire(Position position, ConsoleKey? key);
    Bullet[] FireTick(Position position);
}