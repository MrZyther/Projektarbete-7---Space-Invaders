var map = new Map(15, 15);
var position = new Position(7, 14, 15, 15);
var input = new KeyboardInput();
IMovement movement = new PlayerMovement(input);

Console.Clear();
Console.CursorVisible = false;
while (input.ReadInput())
{
    movement.Move(position);
    Console.SetCursorPosition(0, 0);
    position.Draw(map, 'U');
    map.CreateMap();
    Thread.Sleep(100);
}