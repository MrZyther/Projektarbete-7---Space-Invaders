class Wave(int width, int height, Scoreboard scoreboard, List<Position> formation, IControls movement)
{
    public Target[] Create()
    {
        List<Target> targets = [];
        for (int i = 0; i < 3; i++)
        {
            Position top = new(5 + i * 5, 3, width, height);
            Position mid = new(5 + i * 5, 5, width, height);
            Position low = new(5 + i * 5, 7, width, height);
            formation.AddRange([top, mid, low]);

            Enemy regular = new(movement, new RegularEnemyCannon(), top, 1, 'E');
            ArmoredEnemy armored = new(movement, new BlasterCannon(), mid, 3, 'A');
            RapidfireEnemy rapid = new(movement, new RapidfireCannon(), low, 1, 'R');

            targets.Add(new(regular, top, 10, scoreboard, formation));
            targets.Add(new(armored, mid, 30, scoreboard, formation));
            targets.Add(new(rapid, low, 20, scoreboard, formation));
        }

        return targets.ToArray();
    }
}