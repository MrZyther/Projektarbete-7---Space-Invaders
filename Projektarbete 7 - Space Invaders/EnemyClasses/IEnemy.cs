interface IEnemy
{
    void Advance();
    void Act(ConsoleKey? key, List<Bullet> shots);
    void Draw(Map map);
    bool TryHit(Bullet bullet, out bool destroyed);
}
