class BasicEnemy(IControls movement, ICannon cannon, Position position)
    : Enemy(movement, cannon, position, 1, 'E')
{
    public override void Act(ConsoleKey? key, List<Bullet> shots)
    {
        if (Random.Shared.Next(25) == 0)
        {
            base.Act(key, shots);
        }
    }
}
