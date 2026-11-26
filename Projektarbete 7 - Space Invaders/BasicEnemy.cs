class BasicEnemy : Enemy
{
    public BasicEnemy(IControls movement, ICannon cannon, Position position, int health, char symbol)
     : base (movement, cannon, position, health, symbol)
    {
    }
    public override bool TryHit(
    Bullet bullet,
    out Bullet[] response)
    {
        response = [];
        if (health <= 0 || !bullet.Hits(position))
        {
            return false;
        }
        health = 0;
        return true;
    }
}