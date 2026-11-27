Console.Clear();
Game game = new();
Console.CursorVisible = false;
try
{
    string result = "";
    while (result == "")
    {
        game.Draw();
        Thread.Sleep(60);
        ConsoleKey? key = Console.KeyAvailable
            ? Console.ReadKey(true).Key : null;
        if (key == ConsoleKey.Escape)
        {
            return;
        }
        game.PlayTurn(key);
        result = game.FinishTurn();
    }
    game.Draw();
    Console.WriteLine(result);
}
finally
{
    Console.CursorVisible = true;
}
