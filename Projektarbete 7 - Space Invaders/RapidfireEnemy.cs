class RapidfireEnemy : Enemy
{
    public RapidfireEnemy (IControls movement, ICannon cannon, Position position, int health, char symbol)
    : base(movement, cannon, position, health, symbol)
    {
    }
}