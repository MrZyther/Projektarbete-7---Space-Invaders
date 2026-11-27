internal sealed class Target(Ship defender)
{
    private readonly List<Bullet> incoming = [];

    internal void ReceiveFire(IEnumerable<IEnemy> attackers)
    {
        foreach (IEnemy attacker in attackers)
        {
            // FALL #3:
            // VAD: Arv och beroendeinjektion av tre fiendetyper.
            // HUR: Metoden får fienderna utifrån. De ärver Move och Draw,
            // men skriver över Act med slump, svar på skada eller nedräkning.
            // VARFÖR: Alla kan beskjuta samma mål med olika anfallsmönster.
            attacker.Act(null, incoming);
        }
    }

    internal void AdvanceShots()
    {
        incoming.RemoveAll(bullet => defender.TryHit(bullet)
            || !bullet.Move() || defender.TryHit(bullet));
    }

    internal void ClearShots()
    {
        incoming.Clear();
    }

    internal void DrawShots(Map map)
    {
        foreach (Bullet bullet in incoming)
        {
            bullet.Render(map);
        }
    }
}
