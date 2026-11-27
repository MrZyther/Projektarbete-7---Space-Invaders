class EnemyMovement(List<Position> formation) : IControls
{
    private int direction = 1;
    private bool dropping;

    public void PrepareStep()
    {
        dropping = false;
        foreach (Position position in formation)
        {
            if (!position.Copy().TryMove(direction, 0))
            {
                direction = -direction;
                dropping = true;
                break;
            }
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
