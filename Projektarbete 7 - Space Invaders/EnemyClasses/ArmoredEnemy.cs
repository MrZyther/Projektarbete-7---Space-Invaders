class ArmoredEnemy : Enemy
{
    private int hitsBeforeShots = 2;

    public ArmoredEnemy(
    IControls movement, ICannon cannon, Position position,
    int health, char symbol)
    : base(movement, cannon, position, health, symbol)
    {
    }

    public override bool TryHit(Bullet bullet, out Bullet[] response)
    {
        response = [];
        
        if (health <= 0 || !bullet.Hits(position))
        {
            return false;
        }

        health--;
        hitsBeforeShots--;

        if (hitsBeforeShots == 1)
        {
            response = TryFire(null);
            hitsBeforeShots = 2;
        }

        return true;
    }
}