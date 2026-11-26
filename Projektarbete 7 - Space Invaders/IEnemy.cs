interface IEnemy : IControls
{
    bool IsAlive { get; }
    void Advance();
    Bullet[] TryFire(ConsoleKey? key);
    Bullet[] FireTick();
    void Draw(Map map);
    bool TryHit(Bullet bullet, out Bullet[] response);
}