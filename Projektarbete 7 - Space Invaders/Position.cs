class Position
{
    private int x;
    private int y;
    private readonly int maxWidth;
    private readonly int maxHeight;

    public Position(int x, int y, int maxWidth, int maxHeight)
    {
        this.x = x;
        this.y = y;
        this.maxWidth = maxWidth;
        this.maxHeight = maxHeight;
    }

    public bool TryMove(int dx, int dy) //dx och dy står för delta
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
     public Position Copy()
    {
        return new Position(x, y, maxWidth, maxHeight);
    }
     public bool Overlaps(Position other)
    {
        return x == other.x && y == other.y;
    }
     public bool ReachedBottom()
    {
        return y == maxHeight - 1;
    }
    public void Draw(Map map, char symbol)
    {
        map.SetPosition(x, y, symbol);
    }
}