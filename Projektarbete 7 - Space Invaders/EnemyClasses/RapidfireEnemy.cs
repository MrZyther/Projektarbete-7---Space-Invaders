class RapidfireEnemy(IControls movement, ICannon cannon, Position position)
    : Enemy(movement, cannon, position, 1, 'R')
{
    private int turnsUntilShot = Random.Shared.Next(15, 41);

    public override void Act(ConsoleKey? key, List<Bullet> shots)
    {
        turnsUntilShot--;
        if (turnsUntilShot == 0)
        {
            base.Act(key, shots);
            turnsUntilShot = 30;
        }
    }
}
