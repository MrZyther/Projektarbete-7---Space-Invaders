class RapidfireEnemy : BasicEnemy
{
    public RapidfireEnemy (IControls movement, ICannon cannon, Position position, int health, char symbol)
    : base(movement, cannon, position, health, symbol)
    {
    }
}