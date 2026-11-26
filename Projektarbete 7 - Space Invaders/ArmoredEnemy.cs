class ArmoredEnemy : Enemy
{

    private int hitsBeforeShot = 1;
    public ArmoredEnemy(
    IControls movement, ICannon cannon, Position position,
    int health, char symbol)
    : base(movement, cannon, position, health, symbol)
    {
    }
    public override bool TryHit(Bullet bullet, out Bullet? response)
    {
        response = null;
        
        if (health <= 0 || !bullet.Hits(position))
        {
            return false;
        }
        health--;
        hitsBeforeShot--;
       
        if (hitsBeforeShot == 0)
        {
            Bullet[] shots = base.TryFire(null);
            if (shots.Length > 0)
            {
                response = shots[0];
            }

            hitsBeforeShot = 1;
        }
        return true;
    }
}