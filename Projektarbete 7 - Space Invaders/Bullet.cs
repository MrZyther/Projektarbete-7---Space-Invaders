class Bullet(Position start, int dx = 0, int dy = -1)
{
    private readonly Position position = start.Copy();

    public bool Move()
    {
        return position.TryMove(dx, dy);
    }

    public void Render(Map map)
    {
       char symbol;

        if (dy < 0)
        {
         symbol = '|';
        }
        else
        {
            symbol = '!';
        }

        position.Draw(map, symbol);
    }

    public bool Hits(Position target)
    {
        return position.Overlaps(target);
    }
}