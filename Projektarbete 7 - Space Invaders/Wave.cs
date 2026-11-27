class Wave
{
    private const int MoveInterval = 5;
    private readonly List<Position> formation = [];
    private readonly List<Target> targets = [];
    private readonly EnemyMovement movement;
    private readonly Scoreboard scoreboard;
    private int turnsUntilMove = MoveInterval;

    public Wave(int width, int height, Scoreboard scoreboard)
    {
        this.scoreboard = scoreboard;
        movement = new EnemyMovement(formation);
        for (int x = 5; x <= 15; x += 5)
        {
            Position top = new(x, 3, width, height);
            Position mid = new(x, 5, width, height);
            Position low = new(x, 7, width, height);
            formation.AddRange([top, mid, low]);
            BasicEnemy regular = new(movement, new RegularEnemyCannon(), top);
            ArmoredEnemy armored = new(movement, new BlasterCannon(), mid);
            RapidfireEnemy rapid = new(movement, new RapidfireCannon(), low);
            targets.Add(new Target(regular, top, 10));
            targets.Add(new Target(armored, mid, 30));
            targets.Add(new Target(rapid, low, 20));
        }
    }

    public void TakeHits(List<Bullet> shots)
    {
        targets.RemoveAll(target =>
            target.TryDestroy(shots, scoreboard, formation));
    }

    public void Advance()
    {
        turnsUntilMove--;
        if (turnsUntilMove == 0)
        {
            movement.PrepareStep();
            foreach (Target target in targets)
            {
                target.Advance();
            }

            turnsUntilMove = MoveInterval;
        }
    }

    public void Fire(List<Bullet> shots)
    {
        foreach (Target target in targets)
        {
            target.Fire(shots);
        }
    }

    public string CheckOutcome()
    {
        if (targets.Count == 0)
        {
            return "Alla fiender är borta. Du vann!";
        }

        if (formation.Any(position => position.ReachedBottom()))
        {
            return "Fienderna nådde nedersta raden. Du förlorade!";
        }

        return "";
    }

    public void Draw(Map map)
    {
        foreach (Target target in targets)
        {
            target.Draw(map);
        }
    }
}
