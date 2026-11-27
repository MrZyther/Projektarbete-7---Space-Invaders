internal sealed class EnemyMovement : IControls
{
    private int direction = 1;
    private bool dropping;

    internal void StartWave()
    {
        direction = 1;
        dropping = false;
    }

    internal void PrepareStep(IEnumerable<Enemy> enemies)
    {
        dropping = enemies.Any(enemy => enemy.ReachedSide(direction));
        if (dropping)
        {
            direction = -direction;
        }
    }

    public void Move(Position position, ConsoleKey? key)
    {
        if (dropping)
        {
            position.TryMove(0, 1);
        }
        else
        {
            position.TryMove(direction, 0);
        }
    }
}
