class ArmoredEnemy(IControls movement, ICannon cannon, Position position)
    : Enemy(movement, cannon, position, 3, 'A')
{
    private int hitsTaken;

    public override bool TryHit(Bullet bullet, out bool destroyed)
    {
        if (!base.TryHit(bullet, out destroyed))
        {
            return false;
        }

        hitsTaken++;
        return true;
    }

    public override void Act(ConsoleKey? key, List<Bullet> shots)
    {
        if (hitsTaken == 2)
        {
            base.Act(key, shots);
            hitsTaken = 0;
        }
    }
}
