internal sealed class Position
{
    private int x;
    private int y;
    private readonly int maxWidth;
    private readonly int maxHeight;

    internal Position(int x, int y, int maxWidth, int maxHeight)
    {
        this.x = x;
        this.y = y;
        this.maxWidth = maxWidth;
        this.maxHeight = maxHeight;
    }

    internal bool TryMove(int dx, int dy)
    {
        int nextX = x + dx;
        int nextY = y + dy;
        if (nextX < 0 || nextX >= maxWidth || nextY < 0 || nextY >= maxHeight)
        {
            return false;
        }

        x = nextX;
        y = nextY;
        return true;
    }

    internal Position Copy()
    {
        return new Position(x, y, maxWidth, maxHeight);
    }

    internal bool Overlaps(Position other)
    {
        return x == other.x && y == other.y;
    }

    internal bool ReachedSide(int direction)
    {
        return x + direction < 0 || x + direction >= maxWidth;
    }

    internal bool ReachedBottom()
    {
        return y == maxHeight - 1;
    }

    internal void Draw(Map map, char symbol)
    {
        map.DrawAt(x, y, symbol);
    }
}
