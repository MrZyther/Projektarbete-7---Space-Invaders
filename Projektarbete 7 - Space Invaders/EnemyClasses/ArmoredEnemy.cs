class ArmoredEnemy : Enemy
{
    private int hitsTaken;

    public ArmoredEnemy(IControls movement, ICannon cannon, Position position, int health, char symbol)
        : base(movement, cannon, position, health, symbol)
    {
    }

    public override Bullet[] TryFire(ConsoleKey? key)
    {
        return [];
    }

    public override bool TryHit(Bullet bullet, out Bullet[] response, out bool destroyed)
    {
        if (!base.TryHit(bullet, out response, out destroyed))
        {
            return false;
        }

        hitsTaken++;
        if (hitsTaken == 2 && health > 0)
        {
            response = cannon.TryFire(position, null);
            hitsTaken = 0;
        }

        return true;
    }
}