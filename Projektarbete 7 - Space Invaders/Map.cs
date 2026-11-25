using System.Text;

class Map (int width, int height)
{
    private readonly char[,] grid = new char [width, height];

    public void SetPosition(int x, int y, char symbol)
    {
        grid[x, y] = symbol;
    }

    public void CreateMap()
    {
        for(int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                char symbol = grid[x, y];
                Console.Write(symbol== '\0' ? '.' : symbol);
            
                Console.Write(' ');
            }
            Console.WriteLine();
        }
        Array.Clear(grid);

    }
}