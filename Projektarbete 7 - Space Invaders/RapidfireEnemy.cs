class RapidfireEnemy : Ship, IEnemy
{
    public RapidfireEnemy (IControls movement, ICannon cannon, Position position, int health, char symbol)
    : base(movement, cannon, position, health, symbol)
    {
    }

    public void Draw(Map map)
    {
        base.DrawShip(map);
    }

    public void Advance()
    {
        base.Advance();
    }

    public virtual bool TryHit(Bullet bullet, out Bullet? response)
    {
        response = null;
        if (health <= 0 || !bullet.Hits(position))
        {
            return false;
        }

        health--;
        return true;
    }
}