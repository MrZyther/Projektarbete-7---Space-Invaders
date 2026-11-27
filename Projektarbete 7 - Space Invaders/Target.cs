class Target(IEnemy enemy, Position position, int points, Scoreboard scoreboard, List<Position> formation)
{
    public bool TryHit(Bullet bullet, out Bullet[] response)
    {
        if (!enemy.TryHit(bullet, out response, out bool destroyed))
        {
            return false;
        }

        if (destroyed)
        {
            formation.Remove(position);
            scoreboard.AddPoints(points);
        }

        return true;
    }

    public void Advance()
    {
        enemy.Advance();
    }

    public void Draw(Map map)
    {
        enemy.Draw(map);
    }

    public Bullet[] TryFire()
    {
        return enemy.TryFire(null);
    }

}