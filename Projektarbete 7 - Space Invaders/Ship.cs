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
        return cannon.TryFire(position, key);
    }

    public void DrawShip(Map map)
    {
        if (health > 0)
        {
            position.Draw(map, symbol);
        }
    }
}