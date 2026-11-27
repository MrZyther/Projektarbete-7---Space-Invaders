internal sealed class ArmoredEnemy(
    IControls movement, ICannon cannon, Position start)
    : Enemy(movement, cannon, start, 3, 'A')
{
    private bool hasFired;

    public override void Act(ConsoleKey? key, List<Bullet> shots)
    {
        if (!hasFired && HasOneLifeLeft())
        {
            base.Act(key, shots);
            hasFired = true;
        }
    }
}
