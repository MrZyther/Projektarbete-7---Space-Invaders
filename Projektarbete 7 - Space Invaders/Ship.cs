class Ship : IControls
{
    private readonly IControls movement;
    protected readonly ICannon cannon;
    protected readonly Position position;
    private readonly char symbol;
    protected int health;

    public Ship(
        IControls movement,
        ICannon cannon,
        Position position,
        int health,
        char symbol)
    {
        this.movement = movement;
        this.cannon = cannon;
        this.position = position;
        this.health = health;
        this.symbol = symbol;
    }

    public void Move(Position target, ConsoleKey? key)
    {
        movement.Move(target, key);
    }

    public void Advance()
    {
       if (health <= 0)
        {
            return;
        }
       
        movement.Move(position, null);
    }

    public virtual Bullet[] TryFire(ConsoleKey? key)
    {
        if (health <= 0)
        {
            return [];
        }

        return cannon.TryFire(position, key);
    }

    public void Draw(Map map)
    {
        if (health > 0)
        {
            position.Draw(map, symbol);
        }
    }

    public virtual bool TryHit(Bullet bullet, out Bullet[] response, out bool destroyed)
    {
        response = [];
        destroyed = false;
        if (health <= 0 || !bullet.Hits(position))
        {
            return false;
        }

        health--;
        destroyed = health == 0;
        return true;
    }
}