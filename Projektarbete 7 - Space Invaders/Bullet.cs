internal sealed class Bullet(Position start, int dx = 0, int dy = -1)
{
    private readonly Position position = start.Copy();

    internal bool Move()
    {
        return position.TryMove(dx, dy);
    }

    internal void Render(Map map)
    {
        position.Draw(map, dy < 0 ? '|' : '!');
    }

    internal bool Hits(Position target)
    {
        return position.Overlaps(target);
    }
}
