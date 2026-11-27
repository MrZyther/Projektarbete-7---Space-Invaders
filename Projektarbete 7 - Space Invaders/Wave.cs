internal sealed class Wave(int width, int height, Scoreboard scoreboard)
{
    private const int MoveInterval = 5;
    private readonly Dictionary<Enemy, int> rewards = [];
    private readonly EnemyMovement movement = new();
    private int turnsUntilMove;

    internal void Spawn()
    {
        movement.StartWave();
        turnsUntilMove = MoveInterval;
        for (int x = 5; x <= 15; x += 5)
        {
            Position top = new(x, 3, width, height);
            Position mid = new(x, 5, width, height);
            Position low = new(x, 7, width, height);
            BasicEnemy basic = new(movement, new RegularEnemyCannon(), top);
            ArmoredEnemy armored = new(movement, new BlasterCannon(), mid);
            RapidfireEnemy rapid = new(movement, new RapidfireCannon(), low);
            rewards.Add(basic, 10);
            rewards.Add(armored, 30);
            rewards.Add(rapid, 20);
        }
        scoreboard.StartWave();
    }

    internal bool IsCleared()
    {
        return rewards.Count == 0;
    }

    internal bool HasInvaded()
    {
        return rewards.Keys.Any(enemy => enemy.ReachedBottom());
    }

    internal bool Intercept(Bullet bullet)
    {
        foreach (Enemy enemy in rewards.Keys)
        {
            if (!enemy.TryHit(bullet))
            {
                continue;
            }
            if (enemy.IsDestroyed())
            {
                rewards.Remove(enemy, out int points);
                scoreboard.AddPoints(points);
            }
            return true;
        }
        return false;
    }

    internal void Advance()
    {
        turnsUntilMove--;
        if (turnsUntilMove == 0)
        {
            movement.PrepareStep(rewards.Keys);
            foreach (Enemy enemy in rewards.Keys)
            {
                enemy.Move(null);
            }
            turnsUntilMove = MoveInterval;
        }
    }

    internal void Fire(Target target)
    {
        target.ReceiveFire(rewards.Keys);
    }

    internal void Draw(Map map)
    {
        foreach (Enemy enemy in rewards.Keys)
        {
            enemy.Draw(map);
        }
    }
}
