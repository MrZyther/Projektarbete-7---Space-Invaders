internal abstract class Ship(
    IControls movement, ICannon cannon, Position position, int health,
    char symbol)
{
    internal void Move(ConsoleKey? key)
    {
        // FALL #1:
        // VAD: Subtypspolymorfism och beroendeinjektion via IControls.
        // HUR: Konstruktorn får PlayerMovement eller EnemyMovement.
        // VARFÖR: Samma skeppskod kan följa pilar eller formationens steg.
        movement.Move(position, key);
    }

    public virtual void Act(ConsoleKey? key, List<Bullet> shots)
    {
        // FALL #2:
        // VAD: Subtypspolymorfism och beroendeinjektion via ICannon.
        // HUR: Skeppet anropar den kanon det fick i konstruktorn.
        // VARFÖR: Samma anrop kan ge ett skott, ett skottpar eller en salva.
        shots.AddRange(cannon.TryFire(position, key));
    }

    internal void Draw(Map map)
    {
        if (health > 0)
        {
            position.Draw(map, symbol);
        }
    }

    internal bool TryHit(Bullet bullet)
    {
        if (health == 0 || !bullet.Hits(position))
        {
            return false;
        }

        health--;
        return true;
    }

    protected bool HasOneLifeLeft()
    {
        return health == 1;
    }

    internal bool IsDestroyed()
    {
        return health == 0;
    }

    internal bool ReachedSide(int direction)
    {
        return position.ReachedSide(direction);
    }

    internal bool ReachedBottom()
    {
        return position.ReachedBottom();
    }
}
