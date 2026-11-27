abstract class Enemy(
    IControls movement, ICannon cannon, Position position,
    int health, char symbol)
    : Ship(movement, cannon, position, health, symbol), IEnemy
{
    public void Advance()
    {
        base.Move(null);
    }
}
