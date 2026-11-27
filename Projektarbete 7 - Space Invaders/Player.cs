class Player(IControls movement, ICannon cannon, Position position)
    : Ship(movement, cannon, position, 3, 'P')
{
    public override void Act(ConsoleKey? key, List<Bullet> shots)
    {
        base.Move(key);
        base.Act(key, shots);
    }

    public bool Survives(List<Bullet> shots)
    {
        for (int i = shots.Count - 1; i >= 0; i--)
        {
            Bullet shot = shots[i];
            if (base.TryHit(shot, out bool destroyed) || !shot.Move() ||
                base.TryHit(shot, out destroyed))
            {
                shots.RemoveAt(i);
            }

            if (destroyed)
            {
                return false;
            }
        }

        return true;
    }
}
