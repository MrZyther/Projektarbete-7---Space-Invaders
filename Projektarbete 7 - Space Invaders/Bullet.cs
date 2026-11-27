class Bullet(Position start, int dx = 0, int dy = -1)
{
    private readonly Position position = start.Copy();

    public bool Move()
    {
        return position.TryMove(dx, dy);
    }

    public void Render(Map map)
    {
        position.Draw(map, dy < 0 ? '|' : '!');
    }

    public bool Hits(Position target)
    {
        return position.Overlaps(target);
    }
}
