class PlayerMovement : IControls
{
    public void Move(Position position, ConsoleKey? key)
    {
        if (key == ConsoleKey.LeftArrow)
        {
            position.TryMove(-1, 0);
        }
        else if (key == ConsoleKey.RightArrow)
        {
            position.TryMove(1, 0);
        }
    }
}
 