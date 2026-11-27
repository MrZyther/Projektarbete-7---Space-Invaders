class Target(IEnemy enemy, Position position, int points)
{
    public bool TryDestroy(
        List<Bullet> shots, Scoreboard scoreboard, List<Position> formation)
    {
        for (int i = shots.Count - 1; i >= 0; i--)
        {
            if (enemy.TryHit(shots[i], out bool destroyed))
            {
                shots.RemoveAt(i);
                if (destroyed)
                {
                    formation.Remove(position);
                    scoreboard.AddPoints(points);
                    return true;
                }
            }
        }

        return false;
    }

    public void Advance()
    {
        enemy.Advance();
    }

    public void Draw(Map map)
    {
        enemy.Draw(map);
    }

    public void Fire(List<Bullet> shots)
    {
        enemy.Act(null, shots);
    }
}
