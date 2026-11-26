class Wave
{
    private readonly IEnemy[] enemies;
    private readonly EnemyMovement movement;
    public Wave(IEnemy[] enemies, EnemyMovement movement)
    {
        this.enemies = enemies;
        this.movement = movement;
    }
    public void Advance()
    {
        movement.PrepareStep();
        foreach (IEnemy enemy in enemies)
        {
            enemy.Advance();
        }
        movement.CompleteStep();
    }
    public void Draw(Map map)
    {
        foreach (IEnemy enemy in enemies)
        {
            enemy.Draw(map);
        }
    }
    public bool TryHit(Bullet bullet, out Bullet? response)
    {
        foreach (IEnemy enemy in enemies)
        {
            if (enemy.TryHit(bullet, out response))
            {
                return true;
            }
        }
        response = null;
        return false;
    }
}