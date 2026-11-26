class Ship
{
    private IMovement movement;
    private int health;
    private Position position;
    private char symbol;

    public Ship(IMovement movement, Position position, int health, char symbol)
    {
        this.movement = movement;
        this.position = position;
        this.health = health;
        this.symbol = symbol;
    }
}