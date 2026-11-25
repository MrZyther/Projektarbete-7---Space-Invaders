class PlayerMovement(KeyboardInput input) : IMovement
{
    public void Move(Position position)
    {
        input.RunIfPressed(ConsoleKey.LeftArrow,
        () => position.TryMove(-1, 0));
        input.RunIfPressed(ConsoleKey.RightArrow,
        () => position.TryMove(1, 0));

    }
}