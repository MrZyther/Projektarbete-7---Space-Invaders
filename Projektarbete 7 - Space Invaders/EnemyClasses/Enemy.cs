internal abstract class Enemy(
    IControls movement, ICannon cannon, Position start, int health, char symbol)
    : Ship(movement, cannon, start, health, symbol), IEnemy
{
}
