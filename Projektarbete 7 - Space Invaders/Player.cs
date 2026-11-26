class Player : Ship
{
    public Player(IControls movement, ICannon cannon, Position position, int health, char symbol) 
    : base(movement, cannon, position, health, symbol)
    {
    }

    public bool TryHit(Bullet bullet)
    {
        if (!IsAlive || !bullet.Hits(position))
        {
            return false;
        }

        health--;
        return true;
    }
}