using System.Text;

internal sealed class Map(int width, int height)
{
    private readonly char[,] grid = new char[width, height];

    internal void DrawAt(int x, int y, char symbol)
    {
        grid[x, y] = symbol;
    }

    internal void CreateMap()
    {
        StringBuilder frame = new();
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                char symbol = grid[x, y];
                frame.Append(symbol == '\0' ? '.' : symbol);
                frame.Append(' ');
            }

            frame.AppendLine();
        }

        Console.Write(frame);
        Array.Clear(grid);
    }
}
