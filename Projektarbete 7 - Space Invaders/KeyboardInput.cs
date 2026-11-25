class KeyboardInput
{
    private ConsoleKey KeyPressed;

    public bool ReadInput()
    {
        if(Console.KeyAvailable)
        {
            KeyPressed = Console.ReadKey(true).Key;
        }
        else
        {
            KeyPressed = ConsoleKey.NoName;
        }
        return KeyPressed != ConsoleKey.Escape;
    }

    public void RunIfPressed(ConsoleKey expectedKey, Action action)
    {
        if (KeyPressed == expectedKey)
        {
            action();
        }
    }
}