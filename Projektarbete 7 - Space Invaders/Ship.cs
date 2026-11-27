abstract class Ship(
    IControls movement,
    ICannon cannon,
    Position position,
    int health,
    char symbol)
{
    protected void Move(ConsoleKey? key)
    {
        movement.Move(position, key);
    }

    public virtual void Act(ConsoleKey? key, List<Bullet> shots)
    {
        shots.AddRange(cannon.TryFire(position, key));
    }

    public void Draw(Map map)
    {
        if (health > 0)
        {
            position.Draw(map, symbol);
        }
    }

    public virtual bool TryHit(Bullet bullet, out bool destroyed)
    {
        destroyed = false;
        if (health == 0 || !bullet.Hits(position))
        {
            return false;
        }

        health--;
        destroyed = health == 0;
        return true;
    }
}
