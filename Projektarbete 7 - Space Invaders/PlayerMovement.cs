class PlayerMovement : IMovement
{
 public static ConsoleKey? ReadKey()
 {
 if (Console.KeyAvailable)
 return Console.ReadKey(intercept: true).Key;
 return null;
 }
 public void Move(Position position, ConsoleKey? key)
 {
 if (key == ConsoleKey.LeftArrow)
 position.TryMove(-1, 0);
 else if (key == ConsoleKey.RightArrow)
 position.TryMove(1, 0);
 }
}
