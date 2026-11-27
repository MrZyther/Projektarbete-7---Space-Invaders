Console.CursorVisible = false;
Game game = new();
Console.Clear();

try
{
    game.Draw();
    string result = "";
    while (result == "")
    {
        Thread.Sleep(60);
        ConsoleKey? key = Console.KeyAvailable
            ? Console.ReadKey(intercept: true).Key
            : null;
        if (key == ConsoleKey.Escape)
        {
            break;
        }

        result = game.PlayTurn(key);
        game.Draw();
    }

    Console.WriteLine(result);
}
finally
{
    Console.CursorVisible = true;
}
