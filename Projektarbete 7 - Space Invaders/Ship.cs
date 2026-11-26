class Ship : IControls
{
    private readonly IControls movement;
    private readonly ICannon cannon;
    protected readonly Position position;
    protected readonly char symbol;
    protected int health;

    public Ship(IControls movement, ICannon cannon, Position position, int health, char symbol)
    {
        this.movement = movement;
        this.cannon = cannon;
        this.position = position;
        this.health = health;
        this.symbol = symbol;
    }

    public void Move (Position target, ConsoleKey? key)
    {
        movement.Move(target, key);
    }

    public void Advance()
    {
        movement.Move(position, null);
    }

    public Bullet[] TryFire(ConsoleKey? key)
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
    public virtual bool TryHit(Bullet bullet, out Bullet[] response)
    {
        response = [];
        if (health <= 0 || !bullet.Hits(position))
        {
            return false;
        }

        health--;
        return true;
    }
    public virtual Bullet[] FireTick()
    {
        if (health <= 0)
        {
            return [];
        }

        return cannon.FireTick(position);
    }
}